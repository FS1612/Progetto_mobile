using System;
using UnityEditor;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
    [CustomEditor (typeof(VignetteAndChromaticAberration))]
    class VignetteAndChromaticAberrationEditor : Editor
    {
        private SerializedObject m_SerObj;
        private SerializedProperty m_Mode;
        private SerializedProperty m_Intensity;             // intensity == 0 disables pre pass (optimization)
        private SerializedProperty m_ChromaticAberration;
        private SerializedProperty m_AxialAberration;
        private SerializedProperty m_Blur;                  // blur == 0 disables blur pass (optimization)
        private SerializedProperty m_BlurSpread;
        private SerializedProperty m_BlurDistance;
        private SerializedProperty m_LuminanceDependency;

        public override void OnInspectorGUI ()
        {
            m_SerObj.Update ();

            EditorGUILayout.LabelField("Simulates the common lens artifacts 'Vignette' and 'Aberration'", EditorStyles.miniLabel);

            EditorGUILayout.Slider(m_Intensity, 0.0f, 1.0f, new GUIContent("Vignetting"));
            EditorGUILayout.Slider(m_Blur, 0.0f, 1.0f, new GUIContent(" Blurred Corners"));
            if (m_Blur.floatValue>0.0f)
                EditorGUILayout.Slider(m_BlurSpread, 0.0f, 1.0f, new GUIContent(" Blur Distance"));

            EditorGUILayout.Separator ();

            EditorGUILayout.PropertyField (m_Mode, new GUIContent("Aberration"));
            if (m_Mode.intValue>0)
            {
                EditorGUILayout.Slider(m_ChromaticAberration, 0.0f, 5.0f, new GUIContent("  Tangential Aberration"));
                EditorGUILayout.Slider(m_AxialAberration, 0.0f, 5.0f, new GUIContent("  Axial Aberration"));
                m_LuminanceDependency.floatValue = EditorGUILayout.Slider("  Contrast Dependency", m_LuminanceDependency.floatValue, 0.001f, 1.0f);
                m_BlurDistance.floatValue = EditorGUILayout.Slider("  Blur Distance", m_BlurDistance.floatValue, 0.001f, 5.0f);
            }
            else
                EditorGUILayout.PropertyField (m_ChromaticAberration, new GUIContent(" Chromatic Aberration"));

            m_SerObj.ApplyModifiedProperties();
        }
    }
}
