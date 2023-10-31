
#if UNITY_EDITOR
using Game.Table;
using Unity.VisualScripting;
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

        if(Input.GetKeyDown(KeyCode.Alpha2)) {
            TableController tableController = FindObjectOfType<TableController>();
            Debug.Log("mesa está ligada?: "+ tableController.IsActive);
        }
        
    }

    void OnGUI()
    {
        if(!enabled) return;
        GUI.Label(new Rect(Screen.width/2, 0, 300,50), gameStateController.CurrentState.GetType().ToString());

    }










}

#endif
