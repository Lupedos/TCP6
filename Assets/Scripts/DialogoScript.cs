using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using System;

public class DialogoScript : MonoBehaviour
{
    public string[] dialogos;
    public Image passiente; 
    public int dialogoIndex;
    public TextMeshProUGUI texto;
    public bool inicioConversa;
    public AudioSource[] audios;

    public bool conversando;
    [SerializeField] private CanvasGroup myTextUI;
    private bool fadeIn = false;
    private bool fadeOut = false; 

    [Space(10)]
    public UnityEvent inicioDialogo;
    public UnityEvent fimDialogo;
    
    
    void Start()
    {
        inicioConversa = false; 
    }



    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && conversando)
        {
            if(!inicioConversa)
            {
                InicioDialogo();
            }
            else if (texto.text == dialogos[dialogoIndex] && conversando)
            {
                proximoDialogo();
            }
        }
        
        if(fadeIn)
        {
            if( myTextUI.alpha < 1)
            {
                myTextUI.alpha += Time.deltaTime;
                if(myTextUI.alpha >= 1)
                {
                    fadeIn = false;
                }
            }
        }
        if(fadeOut)
        {
            if( myTextUI.alpha >= 0)
            {
                myTextUI.alpha -= Time.deltaTime;
                if(myTextUI.alpha == 0)
                {
                    fadeOut = false;
                }
            }
        }
        



    }

    
    void InicioDialogo()
    {

        dialogoIndex = 0;
        StartCoroutine(MostrarDialogo());
        inicioConversa = true;
        passiente.gameObject.SetActive(true);
        fadeIn = true;

        inicioDialogo?.Invoke();
    }

    void proximoDialogo()
    {
        dialogoIndex++;

        if(dialogoIndex < dialogos.Length)
        {
            StartCoroutine(MostrarDialogo());
        }
        else
        {
            dialogoIndex = 0;
            inicioConversa = false;
            passiente.gameObject.SetActive(false);
            conversando = false;
            fadeOut = true;  
            fimDialogo?.Invoke();
        }
    }


    IEnumerator MostrarDialogo()
    {
        texto.text = "";
        bool pular = false;
        //Botar audio play aqui
        foreach (char letter in dialogos[dialogoIndex])
        {   
            yield return new WaitForSeconds(0.1f);
            if(pular == false)
            {
                texto.text += letter;
                if(Input.GetButton("Fire1"))
                {
                    texto.text = "";
                    texto.text = dialogos[dialogoIndex];
                    pular = true;
                }
            }
           
            
            
        }
    }
}


