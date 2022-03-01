using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
    [ExecuteInEditMode]
    [RequireComponent (typeof(Camera))]
    [AddComponentMenu ("Image Effects/Camera/Vignette and Chromatic Aberration")]
    public class VignetteAndChromaticAberration : PostEffectsBase
    {
        public enum AberrationMode
        {
            Simple = 0,
            Advanced = 1,
        }


        public AberrationMode mode = AberrationMode.Simple;
        public float intensity = 0.036f;                    // intensity == 0 disables pre pass (optimization)
        public float chromaticAberration = 0.2f;
        public float axialAberration = 0.5f;
        public float blur = 0.0f;                           // blur == 0 disables blur pass (optimization)
        public float blurSpread = 0.75f;
        public float luminanceDependency = 0.25f;
        public float blurDistance = 2.5f;
        public Shader vignetteShader;
        public Shader separableBlurShader;
        public Shader chromAberrationShader;
        
        
        private Material m_VignetteMaterial;
        private Material m_SeparableBlurMaterial;
        private Material m_ChromAberrationMaterial;


        public override bool CheckResources ()
        {
            CheckSupport (false);

            m_VignetteMaterial = CheckShaderAndCreateMaterial (vignetteShader, m_VignetteMaterial);
            m_SeparableBlurMaterial = CheckShaderAndCreateMaterial (separableBlurShader, m_SeparableBlurMaterial);
            m_ChromAberrationMaterial = CheckShaderAndCreateMaterial (chromAberrationShader, m_ChromAberrationMaterial);

            if (!isSupported)
                ReportAutoDisable ();
            return isSupported;
        }
    }
}
