using UnityEngine;
using UnityEditor;
using System.Numerics;

[CustomEditor(typeof(Template))]
public class TemplateEditor : Editor
{

    static EditorWindow gameview;
    Template template;
    bool showReferences = false;
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
        


        using (var check = new EditorGUI.ChangeCheckScope())
        {
            if(showReferences)
            base.OnInspectorGUI();
            if (GUILayout.Button("References"))
            {
                if (!showReferences)
                {
                    showReferences = true;
                }
                else
                {
                    showReferences = false;
                }

            }
            if (check.changed)
            {
               template.Initialize();
            }
        }

        template._colorTemplateBackgroundImage = EditorGUILayout.ColorField("Background Color", template._colorTemplateBackgroundImage);

        template._colorButtonCTA = EditorGUILayout.ColorField("Button Text Color", template._colorButtonCTA);

        template._colorButtonText = EditorGUILayout.ColorField("Button Color", template._colorButtonText);

        template._buttonText = EditorGUILayout.TextField("CTA Text", template._buttonText);

        //AppSpecific

        template._appHeadlineString = EditorGUILayout.TextField("Headline Text", template._appHeadlineString);
       
        template._colorAppHeadline = EditorGUILayout.ColorField("Headline Color", template._colorAppHeadline);
        
        template._appInfoString = EditorGUILayout.TextField("App Info Text", template._appInfoString, GUILayout.Height(60));
        
        template._colorAppInfo = EditorGUILayout.ColorField("Headline Color", template._colorAppInfo);
        
        template._ratingFillAmount = EditorGUILayout.Slider("Rating", template._ratingFillAmount, 0f, 5f);

        template._priceValue = EditorGUILayout.Slider("Price Amount", template._priceValue, 0, 1000);

        template._ratingStarsColor = EditorGUILayout.ColorField("Stars Color", template._ratingStarsColor);


        template.Initialize();

        /*
                template._colorButtonCTA = EditorGUILayout.ColorField("Button Color", template._colorButtonCTA);
                template._buttonCTA.image.color = template._colorButtonCTA;

                template._colorButtonCTA = EditorGUILayout.ColorField("Button Color", template._colorButtonCTA);
                template._buttonCTA.image.color = template._colorButtonCTA;*/

        if (GUILayout.Button("Save Data To JSON"))
        {
           // Debug.Log("generatecoldor");
            template.SaveData();
        }

        if (GUILayout.Button("Load Data From JSON"))
        {
            //Debug.Log("generatecoldor");
            template.LoadData();
        }
        Repaint2();
    }

   
}
