using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Table
{
    public class TableController : MonoBehaviour, IActivable
    {
        private TableObject[] tableObjects;
        public bool IsActive { get; set ; }

        public event Action<bool> Activate = delegate { };

        public void SetActive(bool active)
        {
            IsActive = active;
            Activate?.Invoke(active);
        }

        private void Awake()
        {
            tableObjects = GetComponentsInChildren<TableObject>();
        }






    }

}
