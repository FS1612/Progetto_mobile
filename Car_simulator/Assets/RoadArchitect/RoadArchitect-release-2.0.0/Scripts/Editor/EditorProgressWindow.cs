#if UNITY_EDITOR
#region "Imports"
using UnityEditor;
using UnityEngine;
#endregion


namespace RoadArchitect
{
    /// <summary> Used for progress information for other areas of RA. </summary>
    public class EditorProgressWindow : EditorWindow
    {
        private float seconds = 10.0f;
        private float startValue = 0f;
        private float progress = 0f;
    }
}
#endif
