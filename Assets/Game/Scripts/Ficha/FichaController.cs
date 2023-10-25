using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ToggleGroup))]
public class FichaController : MonoBehaviour, IObjective
{
    public bool IsContaminado = false;
    private ToggleGroup toggleGroup;
    [SerializeField] private Toggle toggleContaminado;
    [SerializeField] private Toggle toggleNaoContaminado;
    

    public bool Complete { get;set; } = false;
    public event Action OnComplete = delegate {};

    public void SetComplete() 
    {
        Complete = true;
        OnComplete?.Invoke();
    }

    void Awake()
    {
        toggleGroup = GetComponent<ToggleGroup>();
    }

    void Start()
    {
        toggleContaminado.onValueChanged.AddListener(OnContaminadoChange);
        toggleNaoContaminado.onValueChanged.AddListener(OnNaoContaminadoChange);
    }

    void OnDestroy()
    {        
        toggleContaminado.onValueChanged.RemoveListener(OnContaminadoChange);
        toggleNaoContaminado.onValueChanged.RemoveListener(OnNaoContaminadoChange);
    }

    private void OnNaoContaminadoChange(bool value)
    {       
        if(value) IsContaminado = false;
        if(!Complete) SetComplete();


    }


    private void OnContaminadoChange(bool value)
    {
        if(value)  IsContaminado = true;
        if(!Complete) SetComplete();

    }



}
