using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class RaioXMinigame : Minigame
{

    //contagem de pontos de click corretos
    [SerializeField] ClickablePointController clickablePointController;
    [SerializeField] private GameObject[] falseSpotPrefab;
    [SerializeField] private GameObject[] trueSpotPrefab;
    [SerializeField] private GameObject leftSpotOnBotton;
    [SerializeField] private GameObject rightSpotOnBotton;

    [SerializeField] private LaminulaConfig RaioXConfig;

    public ClickablePointController ClickablePointController => clickablePointController;
    private CircleCollider2D collider2d;

    //TODO: migrar toda geração de pontos clicáveis para um classe separada e relacionar
    //com o clickablePointsController
    public UnityEvent GeneratedClickablePoints;
    public GameObject GetRandomSpotTrue()
    {
        return trueSpotPrefab[Random.Range(0, trueSpotPrefab.Length)];
    }
    public GameObject GetRandomSpotFalse()
    {
        return falseSpotPrefab[Random.Range(0, falseSpotPrefab.Length)];
    }

    public Vector2 getRandomSpawnPosition => Random.onUnitSphere * collider2d.radius;

    public GameObject ClickableParent => clickablePointController.gameObject;


    private void Awake()
    {
        collider2d = GetComponent<CircleCollider2D>();
    }

    private void Start()
    {

        GenerateClickablePoints(RaioXConfig);
    }

    private void GenerateClickablePoints(LaminulaConfig config)
    {
        GenerateFalses(config);
        GenerateTrues(config);
        GeneratedClickablePoints?.Invoke();
    }

    private void GenerateTrues(LaminulaConfig config)
    {

        for (int i = 0; i < config.GetRandomTrue(); i++)
        {
            //x: 0 -> -1000; y: 0 -> -850
            GameObject instantiatedMicroorg = Instantiate(GetRandomSpotTrue(), ClickableParent.transform, false);
            RectTransform rectTransform = instantiatedMicroorg.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = getRandomSpawnPosition;
            rectTransform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        }

        GenerateSpotOnBottom();


    }

    private void GenerateFalses(LaminulaConfig config)
    {
        if (falseSpotPrefab.Length == 0) return;
        for (int i = 0; i < config.GetRandomFalse(); i++)
        {
            GameObject instantiatedMicroorg = Instantiate(GetRandomSpotFalse(), ClickableParent.transform, false);
            RectTransform rectTransform = instantiatedMicroorg.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = getRandomSpawnPosition;
            rectTransform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        }
    }


    private void GenerateSpotOnBottom()
    {
        //33% mancha esquerda; 33% mancha direta; 33% de não vir nenhum
        int randomValue = Random.Range(0, 3);
        leftSpotOnBotton.SetActive(randomValue == 0);
        rightSpotOnBotton.SetActive(randomValue == 1);
    }

    private void OnDrawGizmosSelected()
    {
        int sphereSize = 2;
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(GetComponent<CircleCollider2D>().bounds.min, sphereSize);
        Gizmos.color = Color.green;

        Gizmos.DrawSphere(GetComponent<CircleCollider2D>().bounds.center, sphereSize);
        Gizmos.color = Color.blue;

        Gizmos.DrawSphere(GetComponent<CircleCollider2D>().bounds.max, sphereSize);
    }


}
