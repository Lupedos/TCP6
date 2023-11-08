using Game.UI;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Table
{
    [RequireComponent(typeof(CanvasGroup))]
    public class TableObjectView : MonoBehaviour, IViewable
    {
        private Image image;
        private IActivable activable;

        public event Action<bool> Activate;

        //[SerializeField] private EventTrigger eventTrigger;
        public CanvasGroup CanvasGroup { get; private set; }

        public bool IsActive { get; private set;}
        private void Awake()
        {
            activable = GetComponent<TableObject>();
            image = GetComponent<Image>();
            CanvasGroup = GetComponent<CanvasGroup>();

        }

        private void Start()
        {
            activable.Activate += OnActive;
        }

        private void OnDestroy()
        {
            activable.Activate -= OnActive;
        }

        private void OnActive(bool activity)
        {
            if (activity) Show();
            else Hide();
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

        public void SetActive(bool active)
        {
            IsActive = active;
            Activate?.Invoke(active);
            
        }
    }

}
