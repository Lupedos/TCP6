using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FichaController : MonoBehaviour
{
    [SerializeField] private Toggle toggleContaminado;
    [SerializeField] private Toggle toggletNaoContaminado;


    void Start()
    {
        toggleContaminado.isOn = false;
        toggletNaoContaminado.isOn = false;
        toggleContaminado.onValueChanged.AddListener(OnContaminadoChange);
        toggletNaoContaminado.onValueChanged.AddListener(OnNaoContaminadoChange);
    }

    void OnDestroy()
    {
                toggleContaminado.onValueChanged.RemoveListener(OnContaminadoChange);
        toggletNaoContaminado.onValueChanged.RemoveListener(OnNaoContaminadoChange);
    }

    private void OnNaoContaminadoChange(bool value)
    {       
        if(value) toggleContaminado.isOn = false;
    }

    private void OnContaminadoChange(bool value)
    {
        if(value) toggletNaoContaminado.isOn = false;
    }
}
