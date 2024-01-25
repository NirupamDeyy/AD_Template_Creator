
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;

public class SaveLoadTemplates : MonoBehaviour
{
    public Template template;

    public TextAsset jsonFile;

    public int loadInt = 2;

    public enum LoadFileBy
    {
        Number,
        TextFile
    }

    public void Awake()
    {
        Initialize();
    }

    public void Initialize()
    {
        Debug.Log("initializing");
        GameObject temp = GameObject.FindGameObjectWithTag("TemplateTag");
        {
            if (temp != null)
            {
                template = temp.GetComponent<Template>();
                if (template == null)
                {
                    Debug.LogError("Template Script not found");
                }
            }
            else
            {
                Debug.LogError("Gameobject with TemplateTag is not found");
            }
        }
        template = temp.GetComponent<Template>();
        SaveSystem.Init();
        SaveSystem.StartSave();

    }


    private string ColorToHexConverter(Color color)
    {
        string hexColor = ColorUtility.ToHtmlStringRGBA(color);
        Debug.Log("Hexadecimal representation: " + hexColor);
        return hexColor;
    }

    private Color HexToColorConverter(string hexColor)
    {
        Color color;
        /*if (ColorUtility.TryParseHtmlString(hexColor, out color))
        {
            return color;
        }
        else
        {
            return Color.grey;
        }*/
        Debug.Log(hexColor);
        ColorUtility.TryParseHtmlString("#" + hexColor, out color);
        return color;
    }




    public void Save()
    {
        string _colorTempBack = ColorToHexConverter(template._colorTemplateBackgroundImage);
        /*float roughness = template.shapeSettings.noiseSettings.roughness;
        float strength = template.shapeSettings.noiseSettings.strength;
        float radius = template.shapeSettings.planetRadius;
        bool move = template.move;
        float speed = template.speed;
        string itemName = assignDeleteButton.itemName;
        float sphereRed = template.red;
        float sphereGreen = template.green;
        float sphereBlue = template.blue;
        float planeRed = planeColour.red;
        float planeGreen = planeColour.green;
        float planeBlue = planeColour.blue;*/

        SaveObject saveObject = new()
        {
            _colorTempBack = _colorTempBack,
            /*roughness = roughness,
            strength = strength,
            radius = radius,
            move = move,
            speed = speed,
            itemName = itemName,
            sphereRed = sphereRed,
            sphereGreen = sphereGreen,
            sphereBlue = sphereBlue,
            planeRed = planeRed,
            planeGreen = planeGreen,
            planeBlue = planeBlue*/
        };

        string json = JsonUtility.ToJson(saveObject);
        //SaveSystem.itemName = itemName;
        SaveSystem.Save(json);
    }

    public void Load(LoadFileBy type)
    {
        
        string saveString = "";
        switch (type)
        { 
            case LoadFileBy.Number:
                SaveSystem.loadNumber = loadInt;
                saveString = SaveSystem.Load();
                break;
            case LoadFileBy.TextFile:

                if (jsonFile != null)
                {
                    // Read the text from the TextAsset
                    saveString = jsonFile.text;
                }
                else
                {
                    Debug.LogError("No text file assigned!");
                }
                break;
        }
       

        if (saveString != null)
        {
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);

            template._colorTemplateBackgroundImage = HexToColorConverter(saveObject._colorTempBack);
            /*template.shapeSettings.noiseSettings.roughness = saveObject.roughness;
            template.shapeSettings.noiseSettings.strength = saveObject.strength;
            template.shapeSettings.planetRadius = saveObject.radius;
            template.move = saveObject.move;
            template.speed = saveObject.speed;
            template.red = saveObject.sphereRed;
            template.green = saveObject.sphereGreen;
            template.blue = saveObject.sphereBlue;
            planeColour.red = saveObject.planeRed;
            planeColour.green = saveObject.planeGreen;
            planeColour.blue = saveObject.planeBlue;*/

            template.Initialize();
        }
    }


    private class SaveObject
    {
        public string _colorTempBack;
/*
        public int resolution;
        public float roughness;
        public float strength;
        public float radius;
        public bool move;
        public float speed;
        public string itemName;
        public float sphereRed;
        public float sphereGreen;
        public float sphereBlue;
        public float planeRed;
        public float planeGreen;
        public float planeBlue;*/
    }

}
