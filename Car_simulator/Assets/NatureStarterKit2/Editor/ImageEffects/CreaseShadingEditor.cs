using System;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
    [CustomEditor(typeof(CreaseShading))]
    class CreaseShadingEditor : Editor {
        SerializedObject serObj;

        SerializedProperty m_intensity;
        SerializedProperty m_softness;
        SerializedProperty m_spread;

        AnimBool m_showSoftnessWarning = new AnimBool();
        AnimBool m_showSpreadWarning = new AnimBool();

        private bool softnessWarningValue { get { return m_softness.intValue > 4; } }
        private bool spreadWarningValue { get { return m_spread.floatValue > 4; } }

        public override void OnInspectorGUI () {
            serObj.Update ();

            EditorGUILayout.Slider(m_intensity, -5.0f, 5.0f, new GUIContent("Intensity"));

            EditorGUILayout.IntSlider(m_softness, 0, 15, new GUIContent("Softness"));
            m_showSoftnessWarning.target = softnessWarningValue;
            if (EditorGUILayout.BeginFadeGroup(m_showSoftnessWarning.faded))
            {
                EditorGUILayout.HelpBox("High Softness value might reduce performance.", MessageType.Warning, false);
            }
            EditorGUILayout.EndFadeGroup();

            EditorGUILayout.Slider(m_spread, 0.0f, 50.0f, new GUIContent("Spread"));
            m_showSpreadWarning.target = spreadWarningValue;
            if (EditorGUILayout.BeginFadeGroup(m_showSpreadWarning.faded))
            {
                EditorGUILayout.HelpBox("High Spread value might introduce visual artifacts.", MessageType.Warning, false);
            }
            EditorGUILayout.EndFadeGroup();

            serObj.ApplyModifiedProperties ();
        }
    }
}
