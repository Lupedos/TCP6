using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : StateController
{
    [SerializeField] private List<State> statesOrdered;

    private int CurrentStateIndex => statesOrdered.IndexOf(CurrentState);
    public bool IsLastState() 
    {
        return CurrentStateIndex == (statesOrdered.Count - 1);
    }

    void Start()
    {
        // if(statesOrdered == null) return;
        CurrentState = statesOrdered[0];
    }




    public void NextState() 
    {
        if(IsLastState()) return;
        CurrentState = statesOrdered[CurrentStateIndex + 1];
    }


}
