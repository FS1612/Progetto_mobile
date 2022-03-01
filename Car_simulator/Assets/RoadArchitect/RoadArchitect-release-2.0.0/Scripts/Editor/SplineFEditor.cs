#if UNITY_EDITOR
#region "Imports"
using UnityEditor;
#endregion


namespace RoadArchitect
{
    [CustomEditor(typeof(SplineF))]
    public class SplineFEditor : Editor
    {
        private SplineF splineF;

        public override void OnInspectorGUI()
        {
            //Intentionally left empty.
        }
    }
}
#endif
