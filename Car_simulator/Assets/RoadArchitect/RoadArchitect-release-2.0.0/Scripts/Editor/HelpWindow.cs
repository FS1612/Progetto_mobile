#if UNITY_EDITOR
#region "Imports"
using UnityEngine;
using UnityEditor;
#endregion


namespace RoadArchitect
{
    public class HelpWindow : EditorWindow
    {
        public void Initialize()
        {
            Rect rect = new Rect(340, 170, 400, 400);
            position = rect;
            Show();
            titleContent.text = "Help Info";
        }
    }
}
#endif
