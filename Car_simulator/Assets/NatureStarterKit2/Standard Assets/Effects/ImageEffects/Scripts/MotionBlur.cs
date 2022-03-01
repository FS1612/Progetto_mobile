using System;
using UnityEngine;

// This class implements simple ghosting type Motion Blur.
// If Extra Blur is selected, the scene will allways be a little blurred,
// as it is scaled to a smaller resolution.
// The effect works by accumulating the previous frames in an accumulation
// texture.
namespace UnityStandardAssets.ImageEffects
{
    [ExecuteInEditMode]
    [AddComponentMenu("Image Effects/Blur/Motion Blur (Color Accumulation)")]
    [RequireComponent(typeof(Camera))]
    public class MotionBlur : ImageEffectBase
    {
        [Range(0.0f, 0.92f)]
        public float blurAmount = 0.8f;
        public bool extraBlur = false;

        private RenderTexture accumTexture;

        override protected void Start()
        {
#pragma warning disable CS0618 // 'SystemInfo.supportsRenderTextures' está obsoleto: 'supportsRenderTextures always returns true, no need to call it'
            if (!SystemInfo.supportsRenderTextures)
#pragma warning restore CS0618 // 'SystemInfo.supportsRenderTextures' está obsoleto: 'supportsRenderTextures always returns true, no need to call it'
            {
                enabled = false;
                return;
            }
            base.Start();
        }

        override protected void OnDisable()
        {
            base.OnDisable();
            DestroyImmediate(accumTexture);
        }
    }
}
