using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace UnityStandardAssets.ImageEffects
{
    [ExecuteInEditMode]
    [RequireComponent (typeof(Camera))]
    [AddComponentMenu ("Image Effects/Noise/Noise And Grain (Filmic)")]
    public class NoiseAndGrain : PostEffectsBase
	{

        public float intensityMultiplier = 0.25f;

        public float generalIntensity = 0.5f;
        public float blackIntensity = 1.0f;
        public float whiteIntensity = 1.0f;
        public float midGrey = 0.2f;

        public bool  dx11Grain = false;
        public float softness = 0.0f;
        public bool  monochrome = false;

        public Vector3 intensities = new Vector3(1.0f, 1.0f, 1.0f);
        public Vector3 tiling = new Vector3(64.0f, 64.0f, 64.0f);
        public float monochromeTiling = 64.0f;

        public FilterMode filterMode = FilterMode.Bilinear;

        public Texture2D noiseTexture;

        public Shader noiseShader;
        private Material noiseMaterial = null;

        public Shader dx11NoiseShader;
        private Material dx11NoiseMaterial = null;

        private static float TILE_AMOUNT = 64.0f;


        public override bool CheckResources ()
		{
            CheckSupport (false);

            noiseMaterial = CheckShaderAndCreateMaterial (noiseShader, noiseMaterial);

            if (dx11Grain && supportDX11)
			{
#if UNITY_EDITOR
                dx11NoiseShader = Shader.Find("Hidden/NoiseAndGrainDX11");
#endif
                dx11NoiseMaterial = CheckShaderAndCreateMaterial (dx11NoiseShader, dx11NoiseMaterial);
            }

            if (!isSupported)
                ReportAutoDisable ();
            return isSupported;
        }

        static void DrawNoiseQuadGrid (RenderTexture source, RenderTexture dest, Material fxMaterial, Texture2D noise, int passNr)
		{
            RenderTexture.active = dest;

            float noiseSize = (noise.width * 1.0f);
            float subDs = (1.0f * source.width) / TILE_AMOUNT;

            fxMaterial.SetTexture ("_MainTex", source);

            GL.PushMatrix ();
            GL.LoadOrtho ();

            float aspectCorrection = (1.0f * source.width) / (1.0f * source.height);
            float stepSizeX = 1.0f / subDs;
            float stepSizeY = stepSizeX * aspectCorrection;
            float texTile = noiseSize / (noise.width * 1.0f);

            fxMaterial.SetPass (passNr);

            GL.Begin (GL.QUADS);

            for (float x1 = 0.0f; x1 < 1.0f; x1 += stepSizeX)
			{
                for (float y1 = 0.0f; y1 < 1.0f; y1 += stepSizeY)
				{
                    float tcXStart = Random.Range (0.0f, 1.0f);
                    float tcYStart = Random.Range (0.0f, 1.0f);

                    //Vector3 v3 = Random.insideUnitSphere;
                    //Color c = new Color(v3.x, v3.y, v3.z);

                    tcXStart = Mathf.Floor(tcXStart*noiseSize) / noiseSize;
                    tcYStart = Mathf.Floor(tcYStart*noiseSize) / noiseSize;

                    float texTileMod = 1.0f / noiseSize;

                    GL.MultiTexCoord2 (0, tcXStart, tcYStart);
                    GL.MultiTexCoord2 (1, 0.0f, 0.0f);
                    //GL.Color( c );
                    GL.Vertex3 (x1, y1, 0.1f);
                    GL.MultiTexCoord2 (0, tcXStart + texTile * texTileMod, tcYStart);
                    GL.MultiTexCoord2 (1, 1.0f, 0.0f);
                    //GL.Color( c );
                    GL.Vertex3 (x1 + stepSizeX, y1, 0.1f);
                    GL.MultiTexCoord2 (0, tcXStart + texTile * texTileMod, tcYStart + texTile * texTileMod);
                    GL.MultiTexCoord2 (1, 1.0f, 1.0f);
                    //GL.Color( c );
                    GL.Vertex3 (x1 + stepSizeX, y1 + stepSizeY, 0.1f);
                    GL.MultiTexCoord2 (0, tcXStart, tcYStart + texTile * texTileMod);
                    GL.MultiTexCoord2 (1, 0.0f, 1.0f);
                    //GL.Color( c );
                    GL.Vertex3 (x1, y1 + stepSizeY, 0.1f);
                }
            }

            GL.End ();
            GL.PopMatrix ();
        }
    }
}
