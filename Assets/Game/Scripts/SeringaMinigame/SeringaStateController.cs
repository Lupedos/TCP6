using UnityEngine;

[RequireComponent(typeof(SeringaForceState))]
[RequireComponent(typeof(SeringaDirectionState))]
public class SeringaStateController : StateController
{


    public State directionState {get;private set;}
    public State forceState { get; private set; }

    void Awake()
    {
        directionState = GetComponent<SeringaDirectionState>();
        forceState = GetComponent<SeringaForceState>();
    }

    void Start()
    {
        CurrentState = directionState;
    }


}
