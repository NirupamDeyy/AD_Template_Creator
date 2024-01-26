using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Template))]
public class TemplateEditor : Editor
{
    static EditorWindow gameview;
    Template template;
    bool showReferences = false;
    string refString = "SHOW REFERENCES";
    void OnEnable()
    {
        template = (Template)target;

        if (gameview == null)
        {
            System.Reflection.Assembly assembly = typeof(UnityEditor.EditorWindow).Assembly;
            System.Type type = assembly.GetType("UnityEditor.GameView");
            gameview = EditorWindow.GetWindow(type);
        }
    }
    void OnDisable()
    {
        gameview = null;
    }
    private void Repaint2()
    {
        if (gameview != null)
        {
            gameview.Repaint();
        }

    }
    public override void OnInspectorGUI()
    {
        if (showReferences)
        {
            base.OnInspectorGUI();
            refString = "HIDE REFERENCES";
        }
        else
        {
            refString = "SHOW REFERENCES";
        }
            
        if (GUILayout.Button(refString))
        {
            showReferences = !showReferences;
        }


        // Section 1: COLORS
        EditorGUILayout.LabelField("COLORS", EditorStyles.boldLabel);
        DrawUILine();

        template._colorTemplateBackgroundImage = EditorGUILayout.ColorField("Background Color", template._colorTemplateBackgroundImage);
        template._colorButtonCTA = EditorGUILayout.ColorField("Button Color", template._colorButtonCTA);
        template._colorButtonText = EditorGUILayout.ColorField("CTA Text Color", template._colorButtonText);
        template._colorAdHeadline = EditorGUILayout.ColorField("Headline Color", template._colorAdHeadline);
        template._colorTextBody = EditorGUILayout.ColorField("Text Body Color", template._colorTextBody);
        template._ratingStarsColor = EditorGUILayout.ColorField("Stars Color", template._ratingStarsColor);

        EditorGUILayout.Space();

        // Section 2: VALUES & TEXTS
        EditorGUILayout.LabelField("VALUES & TEXTS", EditorStyles.boldLabel);
        DrawUILine();

        template._buttonText = EditorGUILayout.TextField("CTA Text", template._buttonText);
        template._appHeadlineString = EditorGUILayout.TextField("Headline Text", template._appHeadlineString);
        template._appInfoString = EditorGUILayout.TextField("App Info Text", template._appInfoString, GUILayout.Height(60));
        template._ratingFillAmount = EditorGUILayout.Slider("Rating", template._ratingFillAmount, 0f, 5f);
        template._priceValue = EditorGUILayout.Slider("Price Amount", template._priceValue, 0, 1000);
        
        EditorGUILayout.Space();

        // Section 3: TRANSFORM
        EditorGUILayout.LabelField("TRANSFORM ADJUSTMENTS", EditorStyles.boldLabel);
        DrawUILine();
        template._templatePosition.x = EditorGUILayout.Slider("Hor", template._templatePosition.x, -1000f, 1000f);
        template._templatePosition.y = EditorGUILayout.Slider("Ver", template._templatePosition.y, -1000f, 1000f);
       
        template._templateWidth = EditorGUILayout.Slider("Width", template._templateWidth, 800f, 1600f);
        template._templateHeight = EditorGUILayout.Slider("Height", template._templateHeight, 410f, 1800f);
        template._rotationZaxis = EditorGUILayout.Slider("Rotation", template._rotationZaxis, -180f, 180f);

        template.InitializeTemplate();

        GUILayout.Space(7);
        GUI.backgroundColor = Color.cyan;
        if (GUILayout.Button("SAVE DATA TO JSON"))
        {
            template.SaveData();
        }
        Repaint2();
    }
    void DrawUILine()
    {
        Rect rect = EditorGUILayout.GetControlRect(false, 1);
        EditorGUI.DrawRect(rect, new Color(0.5f, 0.5f, 0.5f, 1));
        GUILayout.Space(4);
    }

}
