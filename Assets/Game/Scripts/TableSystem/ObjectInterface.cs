using System;
using DG.Tweening;
using Game.Table;
using Game.UI;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class ObjectInterface : MonoBehaviour, IViewable
{
    private TableController tableController;
    [SerializeField] private ViewEventProps eventProps;
    [SerializeField] private TableObjectType type;
    public event Action<bool> Activate;

    public CanvasGroup CanvasGroup { get; private set; }

    public bool IsActive {get; private set;}
    public TableObjectType Type => type;
    private void Awake()
    {
        tableController = FindObjectOfType<TableController>();
        CanvasGroup = GetComponent<CanvasGroup>();
    }
    private void Start()
    {
        Hide();
    }

    public void Hide()
    {    

        if(tableController.IsActive == false) return;

        //TODO: Mover este método para uma classe de extensão "canvasDoFade" passando eventprops como paramentro (outEvent/inEvent)
        CanvasGroup.DOFade(0, eventProps.outEvent.duration).SetEase(eventProps.outEvent.interpolationMode);
        //transform.DOScale(0, eventProps.outEvent.duration).SetEase(eventProps.outEvent.interpolationMode);
        CanvasGroup.interactable = false;
        CanvasGroup.blocksRaycasts = false;
        SetActive(false);

    }

    public void Show()
    {
        if(tableController.IsActive == false) return;

        CanvasGroup.DOFade(1, eventProps.inEvent.duration).SetEase(eventProps.inEvent.interpolationMode);
        //transform.DOScale(Vector3.one, eventProps.outEvent.duration).SetEase(eventProps.outEvent.interpolationMode);

        CanvasGroup.interactable = true;
        CanvasGroup.blocksRaycasts = true;
        SetActive(true);
    }

    public void SetActive(bool active)
    {
        IsActive = active;
        Activate?.Invoke(active);
    }
}





