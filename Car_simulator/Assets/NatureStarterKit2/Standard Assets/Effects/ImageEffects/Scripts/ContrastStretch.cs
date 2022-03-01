using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
    [ExecuteInEditMode]
    [AddComponentMenu("Image Effects/Color Adjustments/Contrast Stretch")]
    public class ContrastStretch : MonoBehaviour
    {
        /// Adaptation speed - percents per frame, if playing at 30FPS.
        /// Default is 0.02 (2% each 1/30s).
        [Range(0.0001f, 1.0f)]
        public float adaptationSpeed = 0.02f;

        /// If our scene is really dark (or really bright), we might not want to
        /// stretch its contrast to the full range.
        /// limitMinimum=0, limitMaximum=1 is the same as not applying the effect at all.
        /// limitMinimum=1, limitMaximum=0 is always stretching colors to full range.

        /// The limit on the minimum luminance (0...1) - we won't go above this.
        [Range(0.0f,1.0f)]
        public float limitMinimum = 0.2f;

        /// The limit on the maximum luminance (0...1) - we won't go below this.
        [Range(0.0f, 1.0f)]
        public float limitMaximum = 0.6f;


        // To maintain adaptation levels over time, we need two 1x1 render textures
        // and ping-pong between them.
        private RenderTexture[] adaptRenderTex = new RenderTexture[2];
        private int curAdaptIndex = 0;


        // Computes scene luminance (grayscale) image
        public Shader   shaderLum;
        private Material m_materialLum;
        protected Material materialLum {
            get {
                if ( m_materialLum == null ) {
                    m_materialLum = new Material(shaderLum);
                    m_materialLum.hideFlags = HideFlags.HideAndDontSave;
                }
                return m_materialLum;
            }
        }

        // Reduces size of the image by 2x2, while computing maximum/minimum values.
        // By repeatedly applying this shader, we reduce the initial luminance image
        // to 1x1 image with minimum/maximum luminances found.
        public Shader   shaderReduce;
        private Material m_materialReduce;
        protected Material materialReduce {
            get {
                if ( m_materialReduce == null ) {
                    m_materialReduce = new Material(shaderReduce);
                    m_materialReduce.hideFlags = HideFlags.HideAndDontSave;
                }
                return m_materialReduce;
            }
        }

        // Adaptation shader - gradually "adapts" minimum/maximum luminances,
        // based on currently adapted 1x1 image and the actual 1x1 image of the current scene.
        public Shader   shaderAdapt;
        private Material m_materialAdapt;
        protected Material materialAdapt {
            get {
                if ( m_materialAdapt == null ) {
                    m_materialAdapt = new Material(shaderAdapt);
                    m_materialAdapt.hideFlags = HideFlags.HideAndDontSave;
                }
                return m_materialAdapt;
            }
        }

        // Final pass - stretches the color values of the original scene, based on currently
        // adpated minimum/maximum values.
        public Shader   shaderApply;
        private Material m_materialApply;
        protected Material materialApply {
            get {
                if ( m_materialApply == null ) {
                    m_materialApply = new Material(shaderApply);
                    m_materialApply.hideFlags = HideFlags.HideAndDontSave;
                }
                return m_materialApply;
            }
        }


        /// Helper function to do gradual adaptation to min/max luminances
        private void CalculateAdaptation( Texture curTexture )
        {
            int prevAdaptIndex = curAdaptIndex;
            curAdaptIndex = (curAdaptIndex+1) % 2;

            // Adaptation speed is expressed in percents/frame, based on 30FPS.
            // Calculate the adaptation lerp, based on current FPS.
            float adaptLerp = 1.0f - Mathf.Pow( 1.0f - adaptationSpeed, 30.0f * Time.deltaTime );
            const float kMinAdaptLerp = 0.01f;
            adaptLerp = Mathf.Clamp( adaptLerp, kMinAdaptLerp, 1 );

            materialAdapt.SetTexture("_CurTex", curTexture );
            materialAdapt.SetVector("_AdaptParams", new Vector4(
                                                        adaptLerp,
                                                        limitMinimum,
                                                        limitMaximum,
                                                        0.0f
                                                        ));
            // clear destination RT so its contents don't need to be restored
            Graphics.SetRenderTarget(adaptRenderTex[curAdaptIndex]);
            GL.Clear(false, true, Color.black);
            Graphics.Blit (
                adaptRenderTex[prevAdaptIndex],
                adaptRenderTex[curAdaptIndex],
                materialAdapt);
        }
    }
}
