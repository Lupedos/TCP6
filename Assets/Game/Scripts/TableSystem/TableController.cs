using System;
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

        public void SetActiveTableObject(TableObjectType type, bool value)
        {
            foreach (TableObject tableObject in tableObjects)
            {
                if(tableObject.ObjectType == type)
                {
                    tableObject.SetActive(value);
                }
            }
        }


    }

}

