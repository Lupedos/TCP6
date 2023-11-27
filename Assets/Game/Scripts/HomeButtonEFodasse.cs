using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeButtonEFodasse : MonoBehaviour
{
    private Button button;
    private SceneLoader sceneLoader;

    private void Awake()
    {
        button = GetComponent<Button>();
        sceneLoader = FindObjectOfType<SceneLoader>();

    }

    private void Start()
    {
        button.onClick.AddListener(sceneLoader.PerformLoadLevelSelectScene);
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(sceneLoader.PerformLoadLevelSelectScene);

    }







}
