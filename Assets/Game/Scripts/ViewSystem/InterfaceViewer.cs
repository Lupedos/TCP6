using DG.Tweening;
using Game.UI;
using UnityEngine;


namespace Game
{
    [RequireComponent(typeof(CanvasGroup))]
    public class InterfaceViewer : MonoBehaviour
    {
        public CanvasGroup CanvasGroup { get; private set; }
        [SerializeField] private ViewEventProps eventProps;

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


}