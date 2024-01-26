using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Template : MonoBehaviour
{
    [Header("References")]
    [Tooltip("Reference to the Template Background Image")]
    [SerializeField]
    private Image _templateBackgroundImage;

    [HideInInspector]
    public Color _colorTemplateBackgroundImage;
    [HideInInspector]
    public float _templateWidth = 800, _templateHeight =470, _rotationZaxis = 0;

    [HideInInspector]
    public Vector2 _templatePosition = Vector2.zero;

    [Tooltip("Reference to the Template Background Image")]
    [SerializeField] 
    private Button _buttonCTA;

    [HideInInspector]
    public Color _colorButtonCTA = Color.cyan;

    [Tooltip("Reference to the Template Background Image")]
    [SerializeField]
    private TMP_Text _buttonTextRef;

    [HideInInspector]
    public Color _colorButtonText = Color.white;

    [HideInInspector]
    public string _buttonText;

    [Header("App References")]
    [Tooltip("Reference to the App Icon Image")]
    public RawImage _appIcon;

    [SerializeField]
    [Tooltip("App Headline")]
    private TMP_Text _appHeadlineText;

    [HideInInspector]
    public string _appHeadlineString;

    [HideInInspector]
    public Color _colorAdHeadline;

    [Tooltip("Text Body")]
    [SerializeField]
    private TMP_Text _appInfoText;

    [HideInInspector]
    public string _appInfoString;

    [HideInInspector]
    public Color _colorTextBody;

    [Tooltip("PlayStore Ratings Image")]
    [SerializeField] 
    private Image _imageStarsRating;

    [HideInInspector]
    public float _ratingFillAmount;
    [HideInInspector]
    public Color _ratingStarsColor;

    [Tooltip("Price of the App")]
    [SerializeField]private TMP_Text _priceText;

    [HideInInspector]
    public float _priceValue;

    [Tooltip("Automatically gets attached when SAVE button is clicked")]
    public SaveLoadTemplates _saveLoadTemplates;



    public void InitializeTemplate()
    {
        _templateBackgroundImage.color = _colorTemplateBackgroundImage;
        _templateBackgroundImage.rectTransform.sizeDelta = new Vector2(_templateWidth, _templateHeight);
        _templateBackgroundImage.rectTransform.rotation = Quaternion.Euler(0f, 0f, _rotationZaxis);
        _templateBackgroundImage.transform.localPosition = _templatePosition;
        _buttonCTA.image.color = _colorButtonCTA;
        _buttonTextRef.color = _colorButtonText;
        _buttonTextRef.text = _buttonText;
        _appHeadlineText.text = _appHeadlineString;
        _appHeadlineText.color = _colorAdHeadline;
        _appInfoText.text = _appInfoString;
        _appInfoText.color = _colorTextBody;
        _imageStarsRating.fillAmount = _ratingFillAmount / 5f;
        _imageStarsRating.color = _ratingStarsColor;
        _priceText.text = "$ " + _priceValue.ToString();

        if( _priceValue <= 0)
        {
            _priceText.text = "FREE";
            _priceText.color = Color.green;
        }
        else
        {
            _priceText.color = Color.black;
        }
    }

    internal void SaveData()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("SaveLoadTempTag");
        if (obj != null)
        {
            _saveLoadTemplates = obj.GetComponent<SaveLoadTemplates>();
        }
        else
        {
            Debug.LogWarning("Save Load Gameobject not found");
        }
        _saveLoadTemplates.Save();
    }
}
