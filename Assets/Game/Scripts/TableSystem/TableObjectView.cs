using Game.Table;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game.Table
{
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
            activable = GetComponent<IActivable>();
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
            image.color = new Color(0, 0, 0, 100);
        }

        public void Show()
        {
            image.color = new Color(0, 0, 0, 255);

        }

        public void SetActive(bool active)
        {
            IsActive = active;
            Activate?.Invoke(active);
            
        }
    }

}
