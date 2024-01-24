using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Template : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    [Tooltip("Reference to the Template Background Image")]
    private Image _templateBackgroundImage;

    [HideInInspector]
    public Color _colorTemplateBackgroundImage;

    [SerializeField]
    [Tooltip("Reference to the Template Background Image")]
    private Button _buttonCTA;

    [HideInInspector]
    public Color _colorButtonCTA;

    [SerializeField]
    [Tooltip("Reference to the Template Background Image")]
    private TMP_Text _buttonText;

    [HideInInspector]
    public Color _colorButtonText;

    [Header("App References")]
    [SerializeField]
    [Tooltip("Reference to the App Icon Image")]
    private RawImage _appIcon;

    [SerializeField]
    [Tooltip("App Title")]
    [TextArea()]
    private string _appTitleText;

    [HideInInspector]
    public Color _colorAppTitleText;

    [SerializeField]
    [Range(0,5)]
    [Tooltip("PlayStore Ratings")]
    private float _rating;

    [SerializeField]
    [Range(0, 1000)]
    [Tooltip("Price of the App")]
    private float _price;

    [SerializeField]
    [Tooltip("App Information")][TextArea()]
    private string _appInfoText;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
