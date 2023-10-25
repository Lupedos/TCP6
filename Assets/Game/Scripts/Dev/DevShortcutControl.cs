
#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DevShortcutControl : MonoBehaviour
{
private LevelController levelController;

    // Start is called before the first frame update
    void Start()
    {
        levelController = FindObjectOfType<LevelController>();
        
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) { levelController?.FinishMinigames(); }
    }



}

#endif
