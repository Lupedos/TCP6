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
    [SerializeField] private GameObject levelCompletedMarkup;
    private Button button;

    public bool IsActive { get; private set; }

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

        SetLevelNumber(levelNumber);

        CheckLevelReleased();
        CheckLevelCompleted();

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

    //quando muda a atividade do objeto
    private void OnActivate(bool value)
    {
        text_button.enabled = value;
        image.enabled = !false;
        button.interactable = value;
    }


    public void LoadLevelOfButtonNumber()
    {
        int startIndexCenasNiveisMenosUm = 3;
        SceneManager.LoadSceneAsync(levelNumber + startIndexCenasNiveisMenosUm);

    }


    public void CheckLevelReleased()
    {
        bool isLevelReleased = SaveLoad.GetLevelCompleted()+1 >= levelNumber;
        SetActive(isLevelReleased);
    }

    public void CheckLevelCompleted()
    {
        bool isLevelCompleted = (SaveLoad.GetLevelCompleted() >= levelNumber);
        levelCompletedMarkup.SetActive(isLevelCompleted);
    }











}
