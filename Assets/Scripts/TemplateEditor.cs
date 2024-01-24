using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Template))]
public class TemplateEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();//for the default GUI stuffs

        Template template = (Template)target;

        if (GUILayout.Button("Generate Color"))
        {
            Debug.Log("generatecoldor");
        }
    }
}
