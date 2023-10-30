using System;
using Game;
using UnityEngine;


public class DialogoController : MonoBehaviour, IActivable
{
    private DialogoScript dialogoScript;
    public bool IsActive {get; private set; }

    public event Action<bool> Activate;

    public void SetActive(bool active)
    {
        IsActive = active;
        Activate?.Invoke(active);
    }

    void Awake()
    {
        dialogoScript = GetComponent<DialogoScript>();
    }

    void Start()
    {

        Activate += OnActivateChange;
    }



    void OnDestroy()
    {
        Activate -= OnActivateChange;

    }

    
    private void OnActivateChange(bool value)
    {
        dialogoScript.enabled = value;

    }






}
