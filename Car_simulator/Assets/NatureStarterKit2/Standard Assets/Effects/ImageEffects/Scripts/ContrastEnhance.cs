using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(Camera))]
    [AddComponentMenu("Image Effects/Color Adjustments/Contrast Enhance (Unsharp Mask)")]
    public class ContrastEnhance : PostEffectsBase
	{
        [Range(0.0f, 1.0f)]
        public float intensity = 0.5f;
        [Range(0.0f,0.999f)]
        public float threshold = 0.0f;

        private Material separableBlurMaterial;
        private Material contrastCompositeMaterial;

        [Range(0.0f,1.0f)]
        public float blurSpread = 1.0f;

        public Shader separableBlurShader = null;
        public Shader contrastCompositeShader = null;


        public override bool CheckResources ()
		{
            CheckSupport (false);

            contrastCompositeMaterial = CheckShaderAndCreateMaterial (contrastCompositeShader, contrastCompositeMaterial);
            separableBlurMaterial = CheckShaderAndCreateMaterial (separableBlurShader, separableBlurMaterial);

            if (!isSupported)
                ReportAutoDisable ();
            return isSupported;
        }
    }
}
