using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
    [ExecuteInEditMode]
    [RequireComponent (typeof(Camera))]
    [AddComponentMenu ("Image Effects/Camera/Camera Motion Blur") ]
    public class CameraMotionBlur : PostEffectsBase
    {
        // make sure to match this to MAX_RADIUS in shader ('k' in paper)
        static float MAX_RADIUS = 10.0f;

        public enum MotionBlurFilter {
            CameraMotion = 0,			// global screen blur based on cam motion
            LocalBlur = 1,				// cheap blur, no dilation or scattering
            Reconstruction = 2,			// advanced filter (simulates scattering) as in plausible motion blur paper
            ReconstructionDX11 = 3,		// advanced filter (simulates scattering) as in plausible motion blur paper
            ReconstructionDisc = 4,		// advanced filter using scaled poisson disc sampling
        }

        // settings
        public MotionBlurFilter filterType = MotionBlurFilter.Reconstruction;
        public bool  preview = false;				// show how blur would look like in action ...
        public Vector3 previewScale = Vector3.one;	// ... given this movement vector

        // params
        public float movementScale = 0.0f;
        public float rotationScale = 1.0f;
        public float maxVelocity = 8.0f;	// maximum velocity in pixels
        public float minVelocity = 0.1f;	// minimum velocity in pixels
        public float velocityScale = 0.375f;	// global velocity scale
        public float softZDistance = 0.005f;	// for z overlap check softness (reconstruction filter only)
        public int velocityDownsample = 1;	// low resolution velocity buffer? (optimization)
        public LayerMask excludeLayers = 0;
        private GameObject tmpCam = null;

        // resources
        public Shader shader;
        public Shader dx11MotionBlurShader;
        public Shader replacementClear;

        private Material motionBlurMaterial = null;
        private Material dx11MotionBlurMaterial = null;

        public Texture2D noiseTexture = null;
        public float jitter = 0.05f;

        // (internal) debug
        public bool  showVelocity = false;
        public float showVelocityScale = 1.0f;

        // camera transforms
        private Matrix4x4 currentViewProjMat;
        private Matrix4x4 prevViewProjMat;
        private int prevFrameCount;
        private bool  wasActive;
        // shortcuts to calculate global blur direction when using 'CameraMotion'
        private Vector3 prevFrameForward = Vector3.forward;
        private Vector3 prevFrameUp = Vector3.up;
        private Vector3 prevFramePos = Vector3.zero;
        private Camera _camera;


        private void CalculateViewProjection () {
            Matrix4x4 viewMat = _camera.worldToCameraMatrix;
            Matrix4x4 projMat = GL.GetGPUProjectionMatrix (_camera.projectionMatrix, true);
            currentViewProjMat = projMat * viewMat;
        }

        public override bool CheckResources () {
            CheckSupport (true, true); // depth & hdr needed
            motionBlurMaterial = CheckShaderAndCreateMaterial (shader, motionBlurMaterial);

            if (supportDX11 && filterType == MotionBlurFilter.ReconstructionDX11) {
                dx11MotionBlurMaterial = CheckShaderAndCreateMaterial (dx11MotionBlurShader, dx11MotionBlurMaterial);
            }

            if (!isSupported)
                ReportAutoDisable ();

            return isSupported;
        }

        void Remember () {
            prevViewProjMat = currentViewProjMat;
            prevFrameForward = transform.forward;
            prevFrameUp = transform.up;
            prevFramePos = transform.position;
        }

        Camera GetTmpCam () {
            if (tmpCam == null) {
                string name = "_" + _camera.name + "_MotionBlurTmpCam";
                GameObject go = GameObject.Find (name);
                if (null == go) // couldn't find, recreate
                    tmpCam = new GameObject (name, typeof (Camera));
                else
                    tmpCam = go;
            }

            tmpCam.hideFlags = HideFlags.DontSave;
            tmpCam.transform.position = _camera.transform.position;
            tmpCam.transform.rotation = _camera.transform.rotation;
            tmpCam.transform.localScale = _camera.transform.localScale;
            tmpCam.GetComponent<Camera>().CopyFrom(_camera);

            tmpCam.GetComponent<Camera>().enabled = false;
            tmpCam.GetComponent<Camera>().depthTextureMode = DepthTextureMode.None;
            tmpCam.GetComponent<Camera>().clearFlags = CameraClearFlags.Nothing;

            return tmpCam.GetComponent<Camera>();
        }

        void StartFrame () {
            // take only x% of positional changes into account (camera motion)
            // TODO: possibly do the same for rotational part
            prevFramePos = Vector3.Slerp(prevFramePos, transform.position, 0.75f);
        }

        static int divRoundUp (int x, int d)
        {
            return (x + d - 1) / d;
        }
    }
}
