using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
    [ExecuteInEditMode]
    [RequireComponent(typeof (Camera))]
    [AddComponentMenu("Image Effects/Color Adjustments/Tonemapping")]
    public class Tonemapping : PostEffectsBase
    {
        public enum TonemapperType
        {
            SimpleReinhard,
            UserCurve,
            Hable,
            Photographic,
            OptimizedHejiDawson,
            AdaptiveReinhard,
            AdaptiveReinhardAutoWhite,
        };

        public enum AdaptiveTexSize
        {
            Square16 = 16,
            Square32 = 32,
            Square64 = 64,
            Square128 = 128,
            Square256 = 256,
            Square512 = 512,
            Square1024 = 1024,
        };

        public TonemapperType type = TonemapperType.Photographic;
        public AdaptiveTexSize adaptiveTextureSize = AdaptiveTexSize.Square256;

        // CURVE parameter
        public AnimationCurve remapCurve;
        private Texture2D curveTex = null;

        // UNCHARTED parameter
        public float exposureAdjustment = 1.5f;

        // REINHARD parameter
        public float middleGrey = 0.4f;
        public float white = 2.0f;
        public float adaptionSpeed = 1.5f;

        // usual & internal stuff
        public Shader tonemapper = null;
        public bool validRenderTextureFormat = true;
        private Material tonemapMaterial = null;
        private RenderTexture rt = null;
        private RenderTextureFormat rtFormat = RenderTextureFormat.ARGBHalf;


        public override bool CheckResources()
        {
            CheckSupport(false, true);

            tonemapMaterial = CheckShaderAndCreateMaterial(tonemapper, tonemapMaterial);
            if (!curveTex && type == TonemapperType.UserCurve)
            {
                curveTex = new Texture2D(256, 1, TextureFormat.ARGB32, false, true);
                curveTex.filterMode = FilterMode.Bilinear;
                curveTex.wrapMode = TextureWrapMode.Clamp;
                curveTex.hideFlags = HideFlags.DontSave;
            }

            if (!isSupported)
                ReportAutoDisable();
            return isSupported;
        }


        public float UpdateCurve()
        {
            float range = 1.0f;
            if (remapCurve.keys.Length < 1)
                remapCurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(2, 1));
            if (remapCurve != null)
            {
                if (remapCurve.length > 0)
                    range = remapCurve[remapCurve.length - 1].time;
                for (float i = 0.0f; i <= 1.0f; i += 1.0f/255.0f)
                {
                    float c = remapCurve.Evaluate(i*1.0f*range);
                    curveTex.SetPixel((int) Mathf.Floor(i*255.0f), 0, new Color(c, c, c));
                }
                curveTex.Apply();
            }
            return 1.0f/range;
        }

        private bool CreateInternalRenderTexture()
        {
            if (rt)
            {
                return false;
            }
            rtFormat = SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.RGHalf) ? RenderTextureFormat.RGHalf : RenderTextureFormat.ARGBHalf;
            rt = new RenderTexture(1, 1, 0, rtFormat);
            rt.hideFlags = HideFlags.DontSave;
            return true;
        }
    }
}
