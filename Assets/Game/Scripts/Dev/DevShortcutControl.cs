
#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DevShortcutControl : MonoBehaviour
{
    public bool Enabled = true;
    private LevelController levelController;
    private GameStateController gameStateController;

    void Start()
    {
        levelController = FindObjectOfType<LevelController>();
        gameStateController = FindObjectOfType<GameStateController>();
    }

    void Update()
    {
        if(!enabled) return;
        if(Input.GetKeyDown(KeyCode.Alpha1)) { levelController?.FinishMinigames(); }

    }

    void OnGUI()
    {
        if(!enabled) return;
        GUI.Label(new Rect(Screen.width/2, 0, 300,50), gameStateController.CurrentState.GetType().ToString());

    }










}

#endif
