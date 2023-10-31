using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelState : State
{
    private SceneLoader sceneLoader;

    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();

    }
    
    public override void StateStart()
    {
        sceneLoader.LoadLevelSelectScene();

    }

    public override void StateExit()
    {

    }



    public override void StateUpdate()
    {

    }


}
