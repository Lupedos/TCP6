using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class telaFinalScript : MonoBehaviour
{
    public bool resultado = false; 
    public int _Acertos;
    public int _Erros;
    private bool fadeIn = false;
    public TextMeshProUGUI texto_Resultado;
    [SerializeField] private CanvasGroup myTextUI;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(resultado)
        {
            fadeIn = true;
            resultado = false;
        }
        

        if(fadeIn)
        {
            if( myTextUI.alpha < 1)
            {
                myTextUI.alpha += Time.deltaTime;
                if(myTextUI.alpha >= 1)
                {
                    fadeIn = false;
                    StartCoroutine(MostrarResultado());
                }
            }
        }
    }
    IEnumerator MostrarResultado()
    {
        texto_Resultado.text = "Acertou:" + _Acertos;
        yield return new WaitForSeconds(0.1f);
        texto_Resultado.text = "Acertou:" + _Acertos +", Erros:"+ _Erros;
        yield return new WaitForSeconds(1f);
        //Mudar de tela aqui
    }
}
