using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
    [ExecuteInEditMode]
    [RequireComponent (typeof(Camera))]
    [AddComponentMenu("Image Effects/Rendering/Screen Space Ambient Occlusion")]
    public class ScreenSpaceAmbientOcclusion : MonoBehaviour
    {
        public enum SSAOSamples
		{
            Low = 0,
            Medium = 1,
            High = 2,
        }

        [Range(0.05f, 1.0f)]
        public float m_Radius = 0.4f;
        public SSAOSamples m_SampleCount = SSAOSamples.Medium;
        [Range(0.5f, 4.0f)]
        public float m_OcclusionIntensity = 1.5f;
        [Range(0, 4)]
        public int m_Blur = 2;
        [Range(1,6)]
        public int m_Downsampling = 2;
        [Range(0.2f, 2.0f)]
        public float m_OcclusionAttenuation = 1.0f;
        [Range(0.00001f, 0.5f)]
        public float m_MinZ = 0.01f;

        public Shader m_SSAOShader;
        private Material m_SSAOMaterial;

        public Texture2D m_RandomTexture;

        private bool m_Supported;

        private static Material CreateMaterial (Shader shader)
        {
            if (!shader)
                return null;
            Material m = new Material (shader);
            m.hideFlags = HideFlags.HideAndDontSave;
            return m;
        }
        private static void DestroyMaterial (Material mat)
        {
            if (mat)
            {
                DestroyImmediate (mat);
                mat = null;
            }
        }

        private void CreateMaterials ()
        {
            if (!m_SSAOMaterial && m_SSAOShader.isSupported)
            {
                m_SSAOMaterial = CreateMaterial (m_SSAOShader);
                m_SSAOMaterial.SetTexture ("_RandomTexture", m_RandomTexture);
            }
        }

        /*
		private void CreateRandomTable (int count, float minLength)
		{
			Random.seed = 1337;
			Vector3[] samples = new Vector3[count];
			// initial samples
			for (int i = 0; i < count; ++i)
				samples[i] = Random.onUnitSphere;
			// energy minimization: push samples away from others
			int iterations = 100;
			while (iterations-- > 0) {
				for (int i = 0; i < count; ++i) {
					Vector3 vec = samples[i];
					Vector3 res = Vector3.zero;
					// minimize with other samples
					for (int j = 0; j < count; ++j) {
						Vector3 force = vec - samples[j];
						float fac = Vector3.Dot (force, force);
						if (fac > 0.00001f)
							res += force * (1.0f / fac);
					}
					samples[i] = (samples[i] + res * 0.5f).normalized;
				}
			}
			// now scale samples between minLength and 1.0
			for (int i = 0; i < count; ++i) {
				samples[i] = samples[i] * Random.Range (minLength, 1.0f);
			}

			string table = string.Format ("#define SAMPLE_COUNT {0}\n", count);
			table += "const float3 RAND_SAMPLES[SAMPLE_COUNT] = {\n";
			for (int i = 0; i < count; ++i) {
				Vector3 v = samples[i];
				table += string.Format("\tfloat3({0},{1},{2}),\n", v.x, v.y, v.z);
			}
			table += "};\n";
			Debug.Log (table);
		}
		*/
    }
}
