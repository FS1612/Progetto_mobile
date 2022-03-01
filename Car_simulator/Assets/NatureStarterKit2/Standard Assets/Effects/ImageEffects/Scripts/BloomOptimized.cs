using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
    [ExecuteInEditMode]
    [RequireComponent (typeof(Camera))]
    [AddComponentMenu ("Image Effects/Bloom and Glow/Bloom (Optimized)")]
    public class BloomOptimized : PostEffectsBase
    {

        public enum Resolution
		{
            Low = 0,
            High = 1,
        }

        public enum BlurType
		{
            Standard = 0,
            Sgx = 1,
        }

        [Range(0.0f, 1.5f)]
        public float threshold = 0.25f;
        [Range(0.0f, 2.5f)]
        public float intensity = 0.75f;

        [Range(0.25f, 5.5f)]
        public float blurSize = 1.0f;

        Resolution resolution = Resolution.Low;
        [Range(1, 4)]
        public int blurIterations = 1;

        public BlurType blurType= BlurType.Standard;

        public Shader fastBloomShader = null;
        private Material fastBloomMaterial = null;


        public override bool CheckResources ()
		{
            CheckSupport (false);

            fastBloomMaterial = CheckShaderAndCreateMaterial (fastBloomShader, fastBloomMaterial);

            if (!isSupported)
                ReportAutoDisable ();
            return isSupported;
        }
    }
}
