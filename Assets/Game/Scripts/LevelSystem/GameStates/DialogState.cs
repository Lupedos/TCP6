using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogState : State
{
    [SerializeField] private DialogoController dialogoController;


    public override void StateStart()
    {
        dialogoController.SetActive(true);
    }

    public override void StateUpdate()
    {
    }

    public override void StateExit()
    {
        dialogoController.SetActive(false);
    }

}
