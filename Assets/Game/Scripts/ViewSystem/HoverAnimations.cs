using Game.UI;
using UnityEngine;
using DG.Tweening;

namespace Game {
    public class HoverAnimations : MonoBehaviour
    {
       [SerializeField]  private RectTransform rectTransform;

        [SerializeField] private ViewEventProps viewEventProps;
        [SerializeField] [Range(1, 2)] private float scaleMultiplier;
        private Vector3 initialScale = Vector3.one;
        
        //private void Awake()
        //{
        //    rectTransform = GetComponent<RectTransform>();
        //}

        private void Start()
        {
            initialScale = rectTransform.localScale;
        }
        public void HoverIn()
        {
            rectTransform.DOScale(initialScale * scaleMultiplier, viewEventProps.inEvent.duration).SetEase(viewEventProps.inEvent.interpolationMode);
        }

        public void HoverOut()
        {
            rectTransform.DOScale(
                initialScale, 
                viewEventProps.outEvent.duration
            ).SetEase(viewEventProps.outEvent.interpolationMode);

        }
    }
}
