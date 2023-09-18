using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Table
{
    public interface IViewable
    {
        public CanvasGroup CanvasGroup { get; }
        public void Show();
        public void Hide();

    }
}