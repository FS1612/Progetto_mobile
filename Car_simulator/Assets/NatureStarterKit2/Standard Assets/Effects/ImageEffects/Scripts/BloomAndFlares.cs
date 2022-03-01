using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
    public enum LensflareStyle34
    {
        Ghosting = 0,
        Anamorphic = 1,
        Combined = 2,
    }

    public enum TweakMode34
    {
        Basic = 0,
        Complex = 1,
    }

    public enum HDRBloomMode
    {
        Auto = 0,
        On = 1,
        Off = 2,
    }

    public enum BloomScreenBlendMode
    {
        Screen = 0,
        Add = 1,
    }

    [ExecuteInEditMode]
    [RequireComponent(typeof(Camera))]
    [AddComponentMenu("Image Effects/Bloom and Glow/BloomAndFlares (3.5, Deprecated)")]
    public class BloomAndFlares : PostEffectsBase
    {
        public TweakMode34 tweakMode = 0;
        public BloomScreenBlendMode screenBlendMode = BloomScreenBlendMode.Add;

        public HDRBloomMode hdr = HDRBloomMode.Auto;
        private bool doHdr = false;
        public float sepBlurSpread = 1.5f;
        public float useSrcAlphaAsMask = 0.5f;

        public float bloomIntensity = 1.0f;
        public float bloomThreshold = 0.5f;
        public int bloomBlurIterations = 2;

        public bool lensflares = false;
        public int hollywoodFlareBlurIterations = 2;
        public LensflareStyle34 lensflareMode = (LensflareStyle34)1;
        public float hollyStretchWidth = 3.5f;
        public float lensflareIntensity = 1.0f;
        public float lensflareThreshold = 0.3f;
        public Color flareColorA = new Color(0.4f, 0.4f, 0.8f, 0.75f);
        public Color flareColorB = new Color(0.4f, 0.8f, 0.8f, 0.75f);
        public Color flareColorC = new Color(0.8f, 0.4f, 0.8f, 0.75f);
        public Color flareColorD = new Color(0.8f, 0.4f, 0.0f, 0.75f);
        public Texture2D lensFlareVignetteMask;

        public Shader lensFlareShader;
        private Material lensFlareMaterial;

        public Shader vignetteShader;
        private Material vignetteMaterial;

        public Shader separableBlurShader;
        private Material separableBlurMaterial;

        public Shader addBrightStuffOneOneShader;
        private Material addBrightStuffBlendOneOneMaterial;

        public Shader screenBlendShader;
        private Material screenBlend;

        public Shader hollywoodFlaresShader;
        private Material hollywoodFlaresMaterial;

        public Shader brightPassFilterShader;
        private Material brightPassFilterMaterial;


        public override bool CheckResources()
        {
            CheckSupport(false);

            screenBlend = CheckShaderAndCreateMaterial(screenBlendShader, screenBlend);
            lensFlareMaterial = CheckShaderAndCreateMaterial(lensFlareShader, lensFlareMaterial);
            vignetteMaterial = CheckShaderAndCreateMaterial(vignetteShader, vignetteMaterial);
            separableBlurMaterial = CheckShaderAndCreateMaterial(separableBlurShader, separableBlurMaterial);
            addBrightStuffBlendOneOneMaterial = CheckShaderAndCreateMaterial(addBrightStuffOneOneShader, addBrightStuffBlendOneOneMaterial);
            hollywoodFlaresMaterial = CheckShaderAndCreateMaterial(hollywoodFlaresShader, hollywoodFlaresMaterial);
            brightPassFilterMaterial = CheckShaderAndCreateMaterial(brightPassFilterShader, brightPassFilterMaterial);

            if (!isSupported)
                ReportAutoDisable();
            return isSupported;
        }

        private void AddTo(float intensity_, RenderTexture from, RenderTexture to)
        {
            addBrightStuffBlendOneOneMaterial.SetFloat("_Intensity", intensity_);
            Graphics.Blit(from, to, addBrightStuffBlendOneOneMaterial);
        }

        private void BlendFlares(RenderTexture from, RenderTexture to)
        {
            lensFlareMaterial.SetVector("colorA", new Vector4(flareColorA.r, flareColorA.g, flareColorA.b, flareColorA.a) * lensflareIntensity);
            lensFlareMaterial.SetVector("colorB", new Vector4(flareColorB.r, flareColorB.g, flareColorB.b, flareColorB.a) * lensflareIntensity);
            lensFlareMaterial.SetVector("colorC", new Vector4(flareColorC.r, flareColorC.g, flareColorC.b, flareColorC.a) * lensflareIntensity);
            lensFlareMaterial.SetVector("colorD", new Vector4(flareColorD.r, flareColorD.g, flareColorD.b, flareColorD.a) * lensflareIntensity);
            Graphics.Blit(from, to, lensFlareMaterial);
        }

        private void BrightFilter(float thresh, float useAlphaAsMask, RenderTexture from, RenderTexture to)
        {
            if (doHdr)
                brightPassFilterMaterial.SetVector("threshold", new Vector4(thresh, 1.0f, 0.0f, 0.0f));
            else
                brightPassFilterMaterial.SetVector("threshold", new Vector4(thresh, 1.0f / (1.0f - thresh), 0.0f, 0.0f));
            brightPassFilterMaterial.SetFloat("useSrcAlphaAsMask", useAlphaAsMask);
            Graphics.Blit(from, to, brightPassFilterMaterial);
        }

        private void Vignette(float amount, RenderTexture from, RenderTexture to)
        {
            if (lensFlareVignetteMask)
            {
                screenBlend.SetTexture("_ColorBuffer", lensFlareVignetteMask);
                Graphics.Blit(from, to, screenBlend, 3);
            }
            else
            {
                vignetteMaterial.SetFloat("vignetteIntensity", amount);
                Graphics.Blit(from, to, vignetteMaterial);
            }
        }

    }
}
