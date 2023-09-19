using DG.Tweening;
using Game.Table;
using Game.UI;
using UnityEngine;

public class TableObjectInterface : MonoBehaviour, IViewable
{
    [SerializeField] private ViewEventProps eventProps;

    public CanvasGroup CanvasGroup { get; private set; }

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
        CanvasGroup.DOFade(0, eventProps.outEvent.duration).SetEase(eventProps.outEvent.interpolationMode);
        //transform.DOScale(0, eventProps.outEvent.duration).SetEase(eventProps.outEvent.interpolationMode);
        CanvasGroup.interactable = false;
        CanvasGroup.blocksRaycasts = false;

    }

    public void Show()
    {
        CanvasGroup.DOFade(1, eventProps.inEvent.duration).SetEase(eventProps.inEvent.interpolationMode);
        //transform.DOScale(Vector3.one, eventProps.outEvent.duration).SetEase(eventProps.outEvent.interpolationMode);

        CanvasGroup.interactable = true;
        CanvasGroup.blocksRaycasts = true;
    }


}





