using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
    [ExecuteInEditMode]
    [RequireComponent (typeof(Camera))]
    [AddComponentMenu ("Image Effects/Edge Detection/Crease Shading")]
    public class CreaseShading : PostEffectsBase
	{
        public float intensity = 0.5f;
        public int softness = 1;
        public float spread = 1.0f;

        public Shader blurShader = null;
        private Material blurMaterial = null;

        public Shader depthFetchShader = null;
        private Material depthFetchMaterial = null;

        public Shader creaseApplyShader = null;
        private Material creaseApplyMaterial = null;


        public override bool CheckResources ()
		{
            CheckSupport (true);

            blurMaterial = CheckShaderAndCreateMaterial (blurShader, blurMaterial);
            depthFetchMaterial = CheckShaderAndCreateMaterial (depthFetchShader, depthFetchMaterial);
            creaseApplyMaterial = CheckShaderAndCreateMaterial (creaseApplyShader, creaseApplyMaterial);

            if (!isSupported)
                ReportAutoDisable ();
            return isSupported;
        }
    }
}
