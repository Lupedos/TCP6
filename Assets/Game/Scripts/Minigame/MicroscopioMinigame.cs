using Game;
using System;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class MicroscopioMinigame : Minigame, IActivable
{

    //contagem de pontos de click corretos
    [SerializeField] private ClickablePointController clickablePointController;
    [SerializeField] private GameObject[] falseMicroorganismPrefab;
    [SerializeField] private GameObject[] trueMicroorganismPrefab;

    [SerializeField] private LaminulaConfig laminulaConfig;
    private CircleCollider2D collider2d;


    public ClickablePointController ClickablePointController => clickablePointController;

    public UnityEvent MicroorgGenerated;
    public GameObject GetTrueRandomMicrooganism()
    {
        return trueMicroorganismPrefab[Random.Range(0, trueMicroorganismPrefab.Length)];
    }
    public GameObject GetFalseRandomMicrooganism()
    {
        return falseMicroorganismPrefab[Random.Range(0, falseMicroorganismPrefab.Length)];
    }

    public Vector2 getMicroorgRandomPosition => Random.onUnitSphere * collider2d.radius;

    public GameObject laminulaField => clickablePointController.gameObject;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Debug.Log(getMicroorgRandomPosition);
    }


    private void Awake()
    {
        collider2d = GetComponent<CircleCollider2D>();
        clickablePointController = GetComponent<ClickablePointController>();

    }

    private void Start()
    {

        // se o jogo ta no modo facil
        //TODO:
        GenerateLaminula(laminulaConfig);

    }

    private void GenerateLaminula(LaminulaConfig config)
    {
        GenerateFalses(config);
        GenerateTrues(config);
        MicroorgGenerated?.Invoke();

    }

    private void GenerateTrues(LaminulaConfig config)
    {

        for (int i = 0; i < config.GetRandomTrue(); i++)
        {
            //x: 0 -> -1000; y: 0 -> -850
            GameObject instantiatedMicroorg = Instantiate(GetTrueRandomMicrooganism(), laminulaField.transform, false);
            RectTransform rectTransform = instantiatedMicroorg.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = getMicroorgRandomPosition;
            rectTransform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        }
    }

    private void GenerateFalses(LaminulaConfig config)
    {
        for (int i = 0; i < config.GetRandomFalse(); i++)
        {
            GameObject instantiatedMicroorg = Instantiate(GetFalseRandomMicrooganism(), laminulaField.transform, false);
            RectTransform rectTransform = instantiatedMicroorg.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = getMicroorgRandomPosition;
            rectTransform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        }
    }


    private void OnDrawGizmosSelected()
    {
        int sphereSize = 5;
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(GetComponent<CircleCollider2D>().bounds.min, sphereSize);
        Gizmos.color = Color.green;

        Gizmos.DrawSphere(GetComponent<CircleCollider2D>().bounds.center, sphereSize);
        Gizmos.color = Color.blue;

        Gizmos.DrawSphere(GetComponent<CircleCollider2D>().bounds.max, sphereSize);
    }





}


[Serializable]
public class LaminulaConfig
{
    [SerializeField] private int minFalse;
    [SerializeField] private int maxFalse;
    [Space(20)]
    [SerializeField] private int minTrue;
    [SerializeField] private int maxTrue;

    public int MinFalse { get => minFalse;  }
    public int MaxFalse { get => maxFalse; }
    public int MinTrue { get => minTrue;  }
    public int MaxTrue { get => maxTrue;  }

    public int GetRandomFalse()
    {
        return Random.Range(MinFalse, MaxFalse);
    }
    public int GetRandomTrue()
    {
        return Random.Range(MinTrue, MaxTrue);
    }

}
