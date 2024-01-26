using System;
using UnityEngine;

public class SaveLoadTemplates : MonoBehaviour
{
    public Template template;

    [HideInInspector]
    public TextAsset jsonFile;

    [HideInInspector]
    public int loadInt = 2;

    public enum LoadFileBy
    {
        Number,
        TextFile
    }

    public void Awake()
    {
        InitializeSL();
    }

    public void InitializeSL() // called through SAVE or LOAD
    {
        //Debug.Log("initializing");
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
        //Debug.Log("Hexadecimal representation: " + hexColor);
        return hexColor;
    }

    private Color HexToColorConverter(string hexColor)
    {
        Color color;
        ColorUtility.TryParseHtmlString("#" + hexColor, out color);
        return color;
    }

    public void Save()
    {
        InitializeSL();
        string colorTempBack = ColorToHexConverter(template._colorTemplateBackgroundImage);
        string colorButtonCTA = ColorToHexConverter(template._colorButtonCTA);
        string colorTextCTA = ColorToHexConverter(template._colorButtonText);
        string colorAdHeadline = ColorToHexConverter(template._colorAdHeadline);
        string colorTextBody = ColorToHexConverter(template._colorTextBody);
        string colorRatingStars = ColorToHexConverter(template._ratingStarsColor);

        string textCTA = template._buttonText;
        string textADHeadline = template._appHeadlineString;
        string textBody = template._appInfoString;
        float valueRating = template._ratingFillAmount;
        float valuePrice = template._priceValue;

        Vector2 templatePosition = template._templatePosition;
        float templateWidth = template._templateWidth;
        float templateHeight = template._templateHeight;
        float rotationZvalue = template._rotationZaxis;

        SaveObject saveObject = new()
        {
            _colorTempBack = colorTempBack,
            _colorButtonCTA = colorButtonCTA,
            _colorTextCTA = colorTextCTA,
            _colorAdHeadline = colorAdHeadline,
            _colorTextBody = colorTextBody,
            _colorRatingStars = colorRatingStars,

            _textADHeadline = textADHeadline,
            _textBody = textBody,
            _textCTA = textCTA,
            _valuePrice = valuePrice,
            _valueRating = valueRating,

            _templatePosition = templatePosition,
            _templateWidth = templateWidth,
            _templateHeight = templateHeight,
            _rotationZvalue = rotationZvalue,
        };

        string json = JsonUtility.ToJson(saveObject);
        //SaveSystem.itemName = itemName;
        SaveSystem.Save(json);
    }
    public void Load(LoadFileBy type)
    {
        InitializeSL();
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
            try
            {
                SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
                template._colorTemplateBackgroundImage = HexToColorConverter(saveObject._colorTempBack);
                template._colorButtonCTA = HexToColorConverter(saveObject._colorButtonCTA);
                template._colorButtonText = HexToColorConverter(saveObject._colorTextCTA);
                template._colorAdHeadline = HexToColorConverter(saveObject._colorAdHeadline);
                template._colorTextBody = HexToColorConverter(saveObject._colorTextBody);
                template._ratingStarsColor = HexToColorConverter(saveObject._colorRatingStars);

                template._buttonText = saveObject._textCTA;
                template._appHeadlineString = saveObject._textADHeadline;
                template._appInfoString = saveObject._textBody;
                template._ratingFillAmount = saveObject._valueRating;
                template._priceValue = saveObject._valuePrice;

                template._templatePosition = saveObject._templatePosition;
                template._templateWidth = saveObject._templateWidth;
                template._templateHeight = saveObject._templateHeight;
                template._rotationZaxis = saveObject._rotationZvalue;

                template.InitializeTemplate();
            }
            catch (Exception ex)
            {
                Debug.LogError("An error occurred while loading data: " + ex.Message);
            }
        }
    }


    private class SaveObject
    {
        //colors
        public string _colorTempBack;
        public string _colorButtonCTA;
        public string _colorAdHeadline;
        public string _colorTextCTA;
        public string _colorTextBody;
        public string _colorRatingStars;

        //Values & texts
        public string _textCTA;
        public string _textADHeadline;
        public string _textBody;
        public float _valueRating;
        public float _valuePrice;

        //Transform adjustments
        public Vector2 _templatePosition;
        public float _templateWidth;
        public float _templateHeight;
        public float _rotationZvalue;
        
    }

}
