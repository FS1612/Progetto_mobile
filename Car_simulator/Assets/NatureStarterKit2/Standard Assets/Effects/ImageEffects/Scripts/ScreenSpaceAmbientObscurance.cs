using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
    [ ExecuteInEditMode]
    [RequireComponent (typeof(Camera))]
    [AddComponentMenu ("Image Effects/Rendering/Screen Space Ambient Obscurance")]
    class ScreenSpaceAmbientObscurance : PostEffectsBase {
        [Range (0,3)]
        public float intensity = 0.5f;
        [Range (0.1f,3)]
        public float radius = 0.2f;
        [Range (0,3)]
        public int blurIterations = 1;
        [Range (0,5)]
        public float blurFilterDistance = 1.25f;
        [Range (0,1)]
        public int downsample = 0;

        public Texture2D rand = null;
        public Shader aoShader= null;

        private Material aoMaterial = null;

        public override bool CheckResources () {
            CheckSupport (true);

            aoMaterial = CheckShaderAndCreateMaterial (aoShader, aoMaterial);

            if (!isSupported)
                ReportAutoDisable ();
            return isSupported;
        }
    }
}
