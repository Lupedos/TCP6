using System.Collections;
using DG.Tweening;
using Game.Table;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class SeringaMinigameController : MonoBehaviour
{
    [SerializeField] private TMP_Text text_message;
    [SerializeField] private PrecisionClick precisionClick;
    [SerializeField] private Button button_stop;
    [SerializeField] private RectTransform seringaObject;
    private SeringaStateController stateController;

    IViewable seringaObjectViewable;

    public PrecisionClick PrecisionClick { get => precisionClick; private set => precisionClick = value; }
    public Button Button_stop { get => button_stop;private set => button_stop = value; }
    public RectTransform SeringaObject { get => seringaObject;private set => seringaObject = value; }
    public SeringaStateController StateController => stateController;
    public IViewable SeringaObjectViewable => seringaObjectViewable;

    void Awake()
    {
        seringaObjectViewable = GetComponent<IViewable>();
        stateController = GetComponent<SeringaStateController>();

    }

    public void Start()
    {
        seringaObjectViewable.Activate += OnSeringaActivate;
    }

    public void OnDestroy()
    {
        seringaObjectViewable.Activate -= OnSeringaActivate;

    }

    public void OnSeringaActivate(bool value) 
    {
        if(value) 
        {
            stateController.enabled = true;
            stateController.SetState(stateController.directionState);
            PrecisionClick.SetActive(true);
        }
        else 
        {
            stateController.enabled = false;
            PrecisionClick.SetActive(false);
        }

    }

    public void SetMessage(string message) 
    {
        text_message.SetText(message);
    }



}