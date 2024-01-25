using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Template : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    [Tooltip("Reference to the Template Background Image")]
    public Image _templateBackgroundImage;

    [HideInInspector]
    [SerializeField]
    public Color _colorTemplateBackgroundImage;

    [Tooltip("Reference to the Template Background Image")]
    public Button _buttonCTA;

    //[HideInInspector]
    public Color _colorButtonCTA = Color.cyan;

    [Tooltip("Reference to the Template Background Image")]
    public TMP_Text _buttonTextRef;

    [HideInInspector]
    public Color _colorButtonText = Color.white;

    [HideInInspector]
    public string _buttonText;

    [Header("App References")]
    [Tooltip("Reference to the App Icon Image")]
    public RawImage _appIcon;

    [Tooltip("App Headline")]
    public TMP_Text _appHeadlineText;

    [HideInInspector]
    public string _appHeadlineString;

    [HideInInspector]
    public Color _colorAppHeadline;

    [Tooltip("App Info")]
    public TMP_Text _appInfoText;

    [HideInInspector]
    public string _appInfoString;

    [HideInInspector]
    public Color _colorAppInfo;

    [Tooltip("PlayStore Ratings Reference Image")]
    public Image _imageStarsRating;

    [Range(0, 5)]
    public float _ratingFillAmount;

    public Color _ratingStarsColor;

    [Tooltip("Price of the App")]
    public TMP_Text _priceText;

    public float _priceValue;

    /*[SerializeField]
    

    [SerializeField]
    [Range(0, 1000)]
    [Tooltip("Price of the App")]
    private float _price;*/

    public SaveLoadTemplates _saveLoadTemplates;


    void Start()
    {
        
    }

    public void Initialize()
    {
        _templateBackgroundImage.color = _colorTemplateBackgroundImage;
        _buttonCTA.image.color = _colorButtonCTA;
        _buttonTextRef.color = _colorButtonText;
        _buttonTextRef.text = _buttonText;
        _appHeadlineText.text = _appHeadlineString;
        _appHeadlineText.color = _colorAppHeadline;
        _appInfoText.text = _appInfoString;
        _appInfoText.color = _colorAppInfo;
        _imageStarsRating.fillAmount = _ratingFillAmount / 5f;
        _imageStarsRating.color = _ratingStarsColor;
        _priceText.text = _priceValue.ToString();

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

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void SaveData()
    {
        _saveLoadTemplates.Save();
    }

    internal void LoadData()
    {
        _saveLoadTemplates.Load(SaveLoadTemplates.LoadFileBy.TextFile);
    }
}
