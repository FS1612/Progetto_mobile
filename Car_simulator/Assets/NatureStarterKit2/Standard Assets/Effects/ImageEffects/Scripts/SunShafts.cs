using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
    [ExecuteInEditMode]
    [RequireComponent (typeof(Camera))]
    [AddComponentMenu ("Image Effects/Rendering/Sun Shafts")]
    public class SunShafts : PostEffectsBase
    {
        public enum SunShaftsResolution
        {
            Low = 0,
            Normal = 1,
            High = 2,
        }

        public enum ShaftsScreenBlendMode
        {
            Screen = 0,
            Add = 1,
        }


        public SunShaftsResolution resolution = SunShaftsResolution.Normal;
        public ShaftsScreenBlendMode screenBlendMode = ShaftsScreenBlendMode.Screen;

        public Transform sunTransform;
        public int radialBlurIterations = 2;
        public Color sunColor = Color.white;
        public Color sunThreshold = new Color(0.87f,0.74f,0.65f);
        public float sunShaftBlurRadius = 2.5f;
        public float sunShaftIntensity = 1.15f;

        public float maxRadius = 0.75f;

        public bool  useDepthTexture = true;

        public Shader sunShaftsShader;
        private Material sunShaftsMaterial;

        public Shader simpleClearShader;
        private Material simpleClearMaterial;


        public override bool CheckResources () {
            CheckSupport (useDepthTexture);

            sunShaftsMaterial = CheckShaderAndCreateMaterial (sunShaftsShader, sunShaftsMaterial);
            simpleClearMaterial = CheckShaderAndCreateMaterial (simpleClearShader, simpleClearMaterial);

            if (!isSupported)
                ReportAutoDisable ();
            return isSupported;
        }
    }
}
