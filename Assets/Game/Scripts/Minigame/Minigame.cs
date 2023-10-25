using System;
using UnityEngine;

public class Minigame : MonoBehaviour, IObjective
{
    public bool Complete { get; set ; } = false;

    public event Action OnComplete = delegate {};

    public void SetComplete() 
    {
        Complete = true;
        OnComplete?.Invoke();
    }
}
