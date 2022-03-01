using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
    [RequireComponent (typeof(Camera))]
    [AddComponentMenu ("Image Effects/Camera/Tilt Shift (Lens Blur)")]
    class TiltShift : PostEffectsBase {
        public enum TiltShiftMode
        {
            TiltShiftMode,
            IrisMode,
        }
        public enum TiltShiftQuality
        {
            Preview,
            Normal,
            High,
        }

        public TiltShiftMode mode = TiltShiftMode.TiltShiftMode;
        public TiltShiftQuality quality = TiltShiftQuality.Normal;

        [Range(0.0f, 15.0f)]
        public float blurArea = 1.0f;

        [Range(0.0f, 25.0f)]
        public float maxBlurSize = 5.0f;

        [Range(0, 1)]
        public int downsample = 0;

        public Shader tiltShiftShader = null;
        private Material tiltShiftMaterial = null;


        public override bool CheckResources () {
            CheckSupport (true);

            tiltShiftMaterial = CheckShaderAndCreateMaterial (tiltShiftShader, tiltShiftMaterial);

            if (!isSupported)
                ReportAutoDisable ();
            return isSupported;
        }
    }
}
