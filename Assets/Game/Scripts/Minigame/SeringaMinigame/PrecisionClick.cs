using DG.Tweening;
using Game;
using System;
using UnityEngine;
using UnityEngine.UI;



public class PrecisionClick : MonoBehaviour, IActivable
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private Scrollbar scrollbar;
    [SerializeField] private RectTransform range;
    [SerializeField] private Button button_Stop;

    [SerializeField] private float minSpeed = 1;
    private float speedMultiplier  = 1;

    [SerializeField] private PrecisionClickConfig easyConfig;
    [SerializeField] private PrecisionClickConfig hardConfig;

    public bool IsActive { get; private set;}
    public Scrollbar Scrollbar { get => scrollbar; set => scrollbar = value; }

    public event Action<bool> Activate;

    /// <summary>
    /// Invoca verdadeiro se ocorreu tentativa de click no botaõ de parada se o ponteiro parou dentro da zona positiva
    /// </summary> 
    public event Action<bool> IsClickOnRange;

    public bool IsPointerInRange()
    {
        //se o ponteiro do slider (região laranja) está situado dentro da faixa de acerto( região verde)
        return Scrollbar.value > 0.5f - range.localScale.x/2  && Scrollbar.value < 0.5f + range.localScale.x/2;
    }
    public float GetSinValue()
    {
        return Mathf.Sin(minSpeed * speedMultiplier * Time.time) / 2 + 0.5f;
    }

    void Start()
    {
        button_Stop.onClick.AddListener(OnButtonStopClicked);
        Activate += OnActivate;
    }

    void OnDestroy()
    {
        button_Stop.onClick.RemoveListener(OnButtonStopClicked);
        Activate -= OnActivate;
    }

    private void OnActivate(bool value)
    {
        button_Stop.interactable = value;
        float alphaTarget = value ? 1 : 0;
        canvasGroup.DOFade(alphaTarget,0.5f).SetEase(Ease.Linear);

    }

    private void OnButtonStopClicked()
    {
        IsClickOnRange?.Invoke(IsPointerInRange());
    }

    private void Update()
    {
        if (!IsActive) return;
        Scrollbar.value = Mathf.Lerp(scrollbar.value, GetSinValue(),10*Time.deltaTime);
        
    }


    public void SetActive(bool active)
    {
        IsActive = active;
        Activate?.Invoke(active);

    }

    public void SetEasyConfig()
    {

        speedMultiplier = easyConfig.SpeedMultiplier;
        range.DOScaleX(easyConfig.RangeScaleX, 0.5f).SetEase(Ease.OutCirc);
    }

    public void SetHardConfig()
    {
        speedMultiplier = hardConfig.SpeedMultiplier;
        range.DOScaleX(hardConfig.RangeScaleX, 0.5f).SetEase(Ease.OutCirc);
    }

    //speedMultiplier: beetween 1 and 2;
    //barWidhtRange: beetween 0.1f to 0.5f
    public void StartLoopMovement(float speedMultiplier, float barWidthRange) 
    {
        this.speedMultiplier = speedMultiplier;
        range.localScale.Set(barWidthRange, range.localScale.y, range.localScale.z);

    }






}



[Serializable]
public struct PrecisionClickConfig
{
    [SerializeField] private float speedMultiplier;
    [SerializeField][Range(0.1f, 1)] private float rangeScaleX;

    public float RangeScaleX { get => rangeScaleX; }
    public float SpeedMultiplier { get => speedMultiplier; }
}


