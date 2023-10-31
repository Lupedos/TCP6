using System.Collections;
using System.Collections.Generic;
using Game.Table;
using UnityEngine;

public class MinigameState : State
{
        private TableController tableController;

    void Start()
    {
        tableController = FindObjectOfType<TableController>();
        tableController.SetActive(false);
    }
    
    public override void StateStart()
    {
        tableController.SetActive(true);
        Debug.Log(tableController.IsActive);
    }

    public override void StateUpdate()
    {
    }

    public override void StateExit()
    {
        tableController.SetActive(true);

    }


}
