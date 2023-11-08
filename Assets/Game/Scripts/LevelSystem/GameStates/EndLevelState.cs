
using UnityEngine.SceneManagement;

public class EndLevelState : State
{
    private SceneLoader sceneLoader;

    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();

    }
    
    public override void StateStart()
    {
        int sceneIndex  = SceneManager.GetActiveScene().buildIndex;

        SaveLoad.SaveLevelCompleted(sceneIndex - 3);
        sceneLoader.LoadLevelSelectScene();

    }

    public override void StateExit()
    {

    }



    public override void StateUpdate()
    {

    }


}
