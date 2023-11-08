using Game.Table;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalFeedbackState : State
{
    private DialogoScript dialogoScript;
    private LevelController levelController;
    [SerializeField] private TableController tableController;
    void Start()
    {
        dialogoScript = FindObjectOfType<DialogoScript>();
        levelController = FindObjectOfType<LevelController>();

    }

    public override void StateStart()
    {
        dialogoScript.enabled = true;
        tableController.SetActiveAllInterfaces(false);
        MostrarDialogoFinal();
      
      


    }


    public override void StateUpdate()
    {
    }

    public override void StateExit()
    {
        dialogoScript.enabled = false;
    }




    private void MostrarDialogoFinal()
    {
        if(levelController.DiagnosticoEstaCorreto()) 
        {
            dialogoScript.IniciarDialogoFinalCerto();
        } else
        {
            dialogoScript.IniciarDialogoFinalErrado();
        }
    }

}
