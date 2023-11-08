using System;
using UnityEngine;

namespace Game.Table
{
    public class TableController : MonoBehaviour, IActivable
    {
        private TableObject[] tableObjects;
        private ObjectInterface[] objectsInterfaces;

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
            objectsInterfaces = FindObjectsOfType<ObjectInterface>();
        }

        public void SetActiveTableObject(TableObjectType type, bool value)
        {
            foreach (TableObject tableObject in tableObjects)
            {
                if(tableObject.ObjectType == type)
                {
                    Debug.Log(tableObject.name + " changed: " + value);
                    tableObject.SetActive(value);
                }
            }
        }
        public void SetActiveObjectInterface(TableObjectType type, bool value)
        {
            foreach (ObjectInterface objectInterface in objectsInterfaces)
            {
                if (objectInterface.Type == type)
                {
                    objectInterface.SetActive(value);
                }
            }
        }

        public void SetActiveAllInterfaces(bool value)
        {
            foreach(ObjectInterface objectInterface in objectsInterfaces)
            {
                objectInterface.SetActive(value);
            }
        }

    }

}

