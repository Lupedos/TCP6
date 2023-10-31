using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogState : State
{
    private DialogoScript dialogoScript;

    void Start()
    {
        dialogoScript = FindObjectOfType<DialogoScript>();
    }

    public override void StateStart()
    {
        dialogoScript.enabled = true;
        dialogoScript.IniciarDialogoInicial();
    }

    public override void StateUpdate()
    {
    }

    public override void StateExit()
    {
        dialogoScript.enabled = false;
    }

}
