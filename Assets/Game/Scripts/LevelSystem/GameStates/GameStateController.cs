using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : StateController
{
    [SerializeField] private List<State> statesOrdered;

    private int CurrentStateIndex => statesOrdered.IndexOf(CurrentState);
    public event Action FinishGameState = delegate {};
    public bool IsLastState() 
    {
        return CurrentStateIndex == (statesOrdered.Count - 1);
    }

    void Start()
    {
        // if(statesOrdered == null) return;
        SetState(statesOrdered[0]);
    }




    public void NextState() 
    {
        Debug.Log("Next state");
        if(IsLastState()) 
        {
            FinishGameState?.Invoke();
            return;
        }
        SetState(statesOrdered[CurrentStateIndex + 1]);
    }


}
