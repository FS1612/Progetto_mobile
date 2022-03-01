using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
    [ExecuteInEditMode]
    [AddComponentMenu("Image Effects/Blur/Blur")]
    public class Blur : MonoBehaviour
    {
        /// Blur iterations - larger number means more blur.
        [Range(0,10)]
        public int iterations = 3;

        /// Blur spread for each iteration. Lower values
        /// give better looking blur, but require more iterations to
        /// get large blurs. Value is usually between 0.5 and 1.0.
        [Range(0.0f,1.0f)]
        public float blurSpread = 0.6f;


        // --------------------------------------------------------
        // The blur iteration shader.
        // Basically it just takes 4 texture samples and averages them.
        // By applying it repeatedly and spreading out sample locations
        // we get a Gaussian blur approximation.

        public Shader blurShader = null;

        static Material m_Material = null;
        protected Material material {
            get {
                if (m_Material == null) {
                    m_Material = new Material(blurShader);
                    m_Material.hideFlags = HideFlags.DontSave;
                }
                return m_Material;
            }
        }

        protected void OnDisable() {
            if ( m_Material ) {
                DestroyImmediate( m_Material );
            }
        }

        // --------------------------------------------------------

        protected void Start()
        {
            // Disable if we don't support image effects
#pragma warning disable CS0618 // 'SystemInfo.supportsImageEffects' está obsoleto: 'supportsImageEffects always returns true, no need to call it'
            if (!SystemInfo.supportsImageEffects) {
#pragma warning restore CS0618 // 'SystemInfo.supportsImageEffects' está obsoleto: 'supportsImageEffects always returns true, no need to call it'
                enabled = false;
                return;
            }
            // Disable if the shader can't run on the users graphics card
            if (!blurShader || !material.shader.isSupported) {
                enabled = false;
                return;
            }
        }

        // Performs one blur iteration.
        public void FourTapCone (RenderTexture source, RenderTexture dest, int iteration)
        {
            float off = 0.5f + iteration*blurSpread;
            Graphics.BlitMultiTap (source, dest, material,
                                   new Vector2(-off, -off),
                                   new Vector2(-off,  off),
                                   new Vector2( off,  off),
                                   new Vector2( off, -off)
                );
        }

        // Downsamples the texture to a quarter resolution.
        private void DownSample4x (RenderTexture source, RenderTexture dest)
        {
            float off = 1.0f;
            Graphics.BlitMultiTap (source, dest, material,
                                   new Vector2(-off, -off),
                                   new Vector2(-off,  off),
                                   new Vector2( off,  off),
                                   new Vector2( off, -off)
                );
        }
    }
}
