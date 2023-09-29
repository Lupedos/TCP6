using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IClickableInterfaceEvents 
{
    public event Action<int> CorrectClick;
    public event Action<int> WrongClick;
    public event Action OnGotThemAllRight;
    public event Action OnTryedAllPoints;

    public void Subscription();

    public void Unsubscription();
}
