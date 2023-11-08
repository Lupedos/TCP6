using System;
using Game;
using UnityEngine;

public class Minigame : MonoBehaviour, IObjective, IActivable
{
    public bool Complete { get; set ; } = false;

    public event Action OnComplete = delegate {};

    public void SetComplete() 
    {
        Complete = true;
        OnComplete?.Invoke();
    }



    public bool IsActive { get; private set; } = false;

    public event Action<bool> Activate;
    public void SetActive(bool active)
    {
        IsActive = active;
        Activate?.Invoke(active);

    }



}
