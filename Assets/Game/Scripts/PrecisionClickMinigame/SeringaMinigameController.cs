using System;
using Game.Table;
using UnityEngine;
using UnityEngine.UI;

public enum SeringaMinigameState {
    ON_DIRECTION,
    DIRECTION_CORRECT,
    DIRECTION_WRONG,
    ON_FORCE,
    FORCE_CORRECT,
    FORCE_WRONG
}


public class SeringaMinigameController : MonoBehaviour
{
    [SerializeField] private PrecisionClick precisionClick;
    [SerializeField] private SeringaAnimationSet animationSet;
    [SerializeField] private Button button_stop;

    IViewable seringaObjectViewable;
    public SeringaMinigameState currentState = SeringaMinigameState.ON_DIRECTION;   
    public event Action<SeringaMinigameState> OnStateUpdate = delegate {};
    public void SetState(SeringaMinigameState state) {
        currentState = state;
        OnStateUpdate?.Invoke(currentState);
    }

    void Awake()
    {
        seringaObjectViewable = GetComponent<IViewable>();

    }

    public void OnEnable()
    {
        seringaObjectViewable.Activate += OnSeringaActiate;
        button_stop.onClick.AddListener(OnButtonStopClicked);
    }

    public void OnDisable()
    {
        seringaObjectViewable.Activate -= OnSeringaActiate;
        button_stop.onClick.RemoveListener(OnButtonStopClicked);

    }

    public void OnSeringaActiate(bool value) 
    {
        SetState(SeringaMinigameState.ON_DIRECTION);
        precisionClick.SetActive(value);


    }

    public void OnButtonStopClicked() {
        //Update seringa minigame state
        if(currentState == SeringaMinigameState.ON_DIRECTION) {
            if(precisionClick.IsPointerInRange()) 
            {
                SetState(SeringaMinigameState.DIRECTION_CORRECT);
            } else 
            {
                SetState(SeringaMinigameState.DIRECTION_WRONG);
            }
            return;
        } 
        if(currentState == SeringaMinigameState.ON_FORCE) {
            if(precisionClick.IsPointerInRange()) 
            {
                SetState(SeringaMinigameState.ON_DIRECTION);
            } else 
            {
                SetState(SeringaMinigameState.ON_FORCE);

            }
            return;
        }    
        
    }




}
