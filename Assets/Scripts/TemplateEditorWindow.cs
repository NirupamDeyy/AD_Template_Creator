using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Template))]
public class TemplateEditorWindow : EditorWindow
{
    [MenuItem("GG_Assignment/CreateTemplate")]
    public static void ShowWindow()
    {
        GetWindow<TemplateEditorWindow>("Template");
    }

    private void OnGUI()
    {

    }
}
