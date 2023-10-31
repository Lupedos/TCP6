using System;
using UnityEngine;
    
    public abstract class StateController : MonoBehaviour
    {
        public State CurrentState { get; protected set;}
        public event Action<State> StateUpdate = delegate {};




        void Update()
        {
            CurrentState.StateUpdate();
        }

    
        public void SetState(State state) {
            CurrentState?.StateExit();
            CurrentState = state;
            StateUpdate.Invoke(state);
            CurrentState.StateStart();
        }





    }

