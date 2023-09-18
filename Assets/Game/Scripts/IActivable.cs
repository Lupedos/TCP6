using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Table
{
    public interface IActivable
    {
        public bool IsActive { get; }
        public event Action<bool> Activate;
        public void SetActive(bool active);

    }
}
