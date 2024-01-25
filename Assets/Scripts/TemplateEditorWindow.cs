using UnityEngine;
using UnityEditor;
using static UnityEngine.GraphicsBuffer;

[CustomEditor(typeof(Template))]
public class TemplateEditorWindow : EditorWindow
{
    static EditorWindow gameview;
    private string prefabPath = "TemplatePrefab"; // Path to the prefab within the Resources folder
    private float _padding = 10f;
    private TextAsset _textAsset;
    private enum FieldType { Number, TextFile }
    private FieldType selectedFieldType = FieldType.Number;
    private int _fileNumber = 0;
    private string[] options = new string[] { "Number", "Text File" };

    private int selectedOptionIndex = 0;
    SaveLoadTemplates _saveLoadTemplates;
    [MenuItem("GG_Assignment/CreateTemplate")]

    void OnEnable()
    {
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
    public static void ShowWindow()
    {
        GetWindow<TemplateEditorWindow>("Template");
        GameObject obj = GameObject.FindGameObjectWithTag("SaveLoadTempTag");
        if(obj == null )
        {
            GameObject prefab = Resources.Load<GameObject>("SLTHolderPrefab");

            if (prefab != null)
            {
                // Instantiate the loaded prefab
                Instantiate(prefab, Vector3.zero, Quaternion.identity);
               
            }
            else
            {
                Debug.LogError("Prefab not found at path: " + "SLTHolderPrefab");
            }
        }
        
    }

    private void OnGUI()
    {
        GUILayout.Space(_padding);
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace(); // Add flexible space to the left
        GUILayout.Label("AD TEMPLATE CREATOR", EditorStyles.boldLabel);
        GUILayout.FlexibleSpace(); // Add flexible space to the right
        GUILayout.EndHorizontal();

        GUILayout.Space(_padding*3);
        GUILayout.BeginHorizontal();
        GUILayout.Label("Create Default Template");
        _saveLoadTemplates = FindObjectOfType<SaveLoadTemplates>();
        if (GUILayout.Button("INSTANTIATE"))
        {
            
           /* if (saveLoadTemplates != null)
            {
                saveLoadTemplates.Initialize();
            }
            else
            {
                Debug.LogError("SaveLoadTemplates component not found in the scene.");
            }*/

            GameObject prefab = Resources.Load<GameObject>("TemplatePrefab");

            if (prefab != null)
            {
                // Instantiate the loaded prefab
                Instantiate(prefab, Vector3.zero, Quaternion.identity);
            }
            else
            {
                Debug.LogError("Prefab not found at path: " + "TemplatePrefab");
            }
        }
        GUILayout.EndHorizontal();

        GUILayout.Space(_padding);

        selectedOptionIndex = EditorGUILayout.Popup("Select Field Type:", selectedOptionIndex, options);
        selectedFieldType = (FieldType)selectedOptionIndex;

        // Render the appropriate field based on the selected field type
        switch (selectedFieldType)
        {
            case FieldType.Number:
                _fileNumber = EditorGUILayout.IntField("Enter Number:", _fileNumber);
                
                GUILayout.BeginHorizontal();
                if (GUILayout.Button("LOAD PREVIOUS"))
                {
                    _fileNumber--;
                    _saveLoadTemplates.loadInt = _fileNumber;
                    _saveLoadTemplates.Load(SaveLoadTemplates.LoadFileBy.Number);
                    Repaint2();
                }
                if (GUILayout.Button("LOAD"))
                {
                    _saveLoadTemplates.loadInt = _fileNumber;
                    _saveLoadTemplates.Load(SaveLoadTemplates.LoadFileBy.Number);
                    Repaint2();

                }
                if (GUILayout.Button("LOAD NEXT"))
                {
                    _fileNumber++;
                    _saveLoadTemplates.loadInt = _fileNumber;
                    _saveLoadTemplates.Load(SaveLoadTemplates.LoadFileBy.Number);
                    Repaint2();
                }
                GUILayout.EndHorizontal();
                break;

            case FieldType.TextFile:
                _textAsset = (TextAsset)EditorGUILayout.ObjectField("Select a Text File:", _textAsset, typeof(TextAsset), false);
                if (GUILayout.Button("LOAD"))
                {
                    _saveLoadTemplates.jsonFile = _textAsset;
                    _saveLoadTemplates.Load(SaveLoadTemplates.LoadFileBy.TextFile);
                    Repaint2();
                }
                break;
            default:
                break;
        }
        GUILayout.Space(_padding);
    }


}
