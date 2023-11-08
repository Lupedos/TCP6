using System;
using UnityEngine;


namespace Game.Table
{
    //TODO: Mudar depois?
    public enum TableObjectType
    {
        CADERNO,
        FICHA,
        SERINGA,
        MICROSCOPIO,
        RAIO_X
    }


    [RequireComponent(typeof(TableObjectView))] 
    public class TableObject : MonoBehaviour, IActivable
    {
        [SerializeField] private TableObjectType objectType;

        public bool IsActive { get;private set; } = true;
        
        public TableObjectType ObjectType { get => objectType; }

        public event Action<bool> Activate;

        public void SetActive(bool active)
        {
            IsActive = active;
            Activate?.Invoke(active);
        }


    }
}






