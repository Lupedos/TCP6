using DG.Tweening;
using Game.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class SceneLoader : MonoBehaviour
{
    CanvasGroup canvasGroup;

    [SerializeField] private ViewEventProps viewEventProps;
    
    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
    void Start()
    {
        canvasGroup.alpha = 1;
        TransitionOut();
        Debug.Log(SceneManager.GetActiveScene());
    }

    public void PerformLoadNextLeveScene() 
    {
        TransitionIn();
        Invoke(nameof(LoadNextScene), viewEventProps.inEvent.duration);

    }

    public void PerformLoadLevelSelectScene() 
    {
        TransitionIn();
        Invoke(nameof(LoadLevelSelectScene), viewEventProps.inEvent.duration);

    }


    public void LoadNextScene() 
    {

        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextLevelScene = sceneIndex + 1;
        SceneManager.LoadSceneAsync(nextLevelScene,LoadSceneMode.Single);


    }

    public void LoadLevelSelectScene() 
    {
        int LevelSelecSceneIndex = 0;
        SceneManager.LoadSceneAsync(LevelSelecSceneIndex,LoadSceneMode.Single);

    }

    public void TransitionIn() 
    {        
        canvasGroup.DOFade(1, viewEventProps.outEvent.duration).SetEase(viewEventProps.outEvent.interpolationMode);
        canvasGroup.blocksRaycasts = true;
    }


    public void TransitionOut() 
    {
        canvasGroup.DOFade(0, viewEventProps.outEvent.duration).SetEase(viewEventProps.outEvent.interpolationMode);
        canvasGroup.blocksRaycasts = false;

    }

}
