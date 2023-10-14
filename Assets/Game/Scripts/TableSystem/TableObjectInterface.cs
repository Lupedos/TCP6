using System;
using DG.Tweening;
using Game.Table;
using Game.UI;
using UnityEngine;

public class TableObjectInterface : MonoBehaviour, IViewable
{
    [SerializeField] private ViewEventProps eventProps;

    public event Action<bool> Activate;

    public CanvasGroup CanvasGroup { get; private set; }

    public bool IsActive {get; private set;}

    private void Awake()
    {
        CanvasGroup = GetComponent<CanvasGroup>();
    }
    private void Start()
    {
        Hide();
    }

    public void Hide()
    {
        //TODO: Mover este método para uma classe de extensão "canvasDoFade" passando eventprops como paramentro (outEvent/inEvent)
        CanvasGroup.DOFade(0, eventProps.outEvent.duration).SetEase(eventProps.outEvent.interpolationMode);
        //transform.DOScale(0, eventProps.outEvent.duration).SetEase(eventProps.outEvent.interpolationMode);
        CanvasGroup.interactable = false;
        CanvasGroup.blocksRaycasts = false;
        SetActive(false);

    }

    public void Show()
    {
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





