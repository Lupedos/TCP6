
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelState : State
{
    private SceneLoader sceneLoader;
    [SerializeField] private LevelConfigurator levelConfigurator;
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();

    }
    
    public override void StateStart()
    {
        int sceneIndex  = SceneManager.GetActiveScene().buildIndex;

        SaveLoad.SaveLevelCompleted(sceneIndex - 3);

        if (levelConfigurator.Config.CarregaProximoLevel)
        {
            sceneLoader.PerformLoadNextLeveScene();
        } else
        {
            sceneLoader.PerformLoadLevelSelectScene();

        }

    }

    public override void StateExit()
    {

    }



    public override void StateUpdate()
    {

    }


}
