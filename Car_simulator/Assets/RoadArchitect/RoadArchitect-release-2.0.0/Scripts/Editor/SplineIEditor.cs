#if UNITY_EDITOR
#region "Imports"
using UnityEditor;
#endregion


namespace RoadArchitect
{
    [CustomEditor(typeof(SplineI))]
    public class SplineIEditor : Editor
    {
        private SplineI splineI;

        public override void OnInspectorGUI()
        {
            //Intentionally left empty.
        }
    }
}
#endif
