using Game;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectButton : MonoBehaviour, IActivable
{
    public int levelNumber = 1;

    [SerializeField] private TMP_Text text_button;
    [SerializeField] private Image image;
    private Button button;
    public bool IsActive {get; private set;}

    public event Action<bool> Activate;

    private void Awake()
    {
        button = GetComponent<Button>();
    }
    public void SetActive(bool active)
    {
        IsActive = active;
        Activate?.Invoke(active);
    }


    private void Start()
    {
        Activate += OnActivate;
        button.onClick.AddListener(LoadLevelOfButtonNumber);
    }

    private void OnDestroy()
    {
        Activate -= OnActivate;
        button.onClick.RemoveListener(LoadLevelOfButtonNumber);

    }

    public void SetLevelNumber(int levelNumber)
    {
        this.levelNumber = levelNumber;
        text_button.SetText(levelNumber.ToString());
    }

    private void OnActivate(bool value)
    {
        if(value)
        {
            text_button.enabled = true;
            image.enabled = (false);
            button.interactable = true;
        }
        else
        {
            text_button.enabled = (false);
            image.enabled = (true);
            button.interactable = false;
        }
    }


    public void LoadLevelOfButtonNumber()
    {
        int startIndexCenasNiveisMenosUm = 3;
        SceneManager.LoadSceneAsync(levelNumber + startIndexCenasNiveisMenosUm);

    }











}
