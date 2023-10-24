using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    protected StateController stateController;
    void Awake()
    {
        stateController = GetComponent<StateController>();
        
    }

    public abstract void StateStart();
    public abstract void StateUpdate();
    public abstract void StateExit();

}
