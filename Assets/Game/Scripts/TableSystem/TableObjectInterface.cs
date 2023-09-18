using Game.Table;
using Game.UI;
using UnityEngine;

public class TableObjectInterface : MonoBehaviour, IViewable
{
    [SerializeField] private ViewEventProps _eventProps;

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
        CanvasGroup.alpha = 0;
        CanvasGroup.interactable = false;
        CanvasGroup.blocksRaycasts = false;

    }

    public void Show()
    {
        CanvasGroup.alpha = 1;
        CanvasGroup.interactable = true;
        CanvasGroup.blocksRaycasts = true;
    }
}





