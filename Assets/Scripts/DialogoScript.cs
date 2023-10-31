using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class DialogoScript : MonoBehaviour
{
    public string[] dialogos;
    public string[] dialogosFinalCerto;
    public string[] dialogosFinalErrado;
    public bool ganhou;
    public Image passiente;
    public Image[] balao;
    public int dialogoIndex;
    public TextMeshProUGUI texto;
    public bool inicioConversa;
    public AudioSource[] audios;

    public bool conversando;
    public bool final;
    [SerializeField] private CanvasGroup myTextUI;
    private bool fadeIn = false;
    private bool fadeOut = false;
    public bool h = false; 

    [Space(20)]
    public UnityEvent DialogoIniciou;
    public UnityEvent DialogoTerminou;
    
    void Start()
    {
        inicioConversa = false; 
        fadeOut = true; 
    }

    public void IniciarDialogoInicial() 
    {
        DialogoIniciou?.Invoke();
        InicioDialogo(dialogos);
    }

    public void IniciarDialogoFinalCerto() 
    {
        ganhou = true;
        final = true;
        InicioDialogo(dialogosFinalCerto);

        DialogoIniciou?.Invoke();

    }

    public void IniciarDialogoFinalErrado() 
    {
        ganhou = false;
        final = true;
        InicioDialogo(dialogosFinalErrado);

        DialogoIniciou?.Invoke();

    }


    // Update is called once per frame
    void Update()
    {

        
        if(Input.GetButtonDown("Fire1") && conversando)
        {
            if(!inicioConversa)
            {
                IniciarDialogoInicial();
            }
            else if (texto.text == dialogos[dialogoIndex] && conversando)
            {
                proximoDialogo(dialogos);
            }
        
        }

        if(final && ganhou)
        {
            if(!inicioConversa)
            InicioDialogo(dialogosFinalCerto);


            if(Input.GetButtonDown("Fire1") && texto.text == dialogosFinalCerto[dialogoIndex])
            {
                proximoDialogo(dialogosFinalCerto);
            }


        }
        else  if(final && ganhou == false)
        {
            if(!inicioConversa) InicioDialogo(dialogosFinalErrado);

            if(Input.GetButtonDown("Fire1") && texto.text == dialogosFinalErrado[dialogoIndex])
            {
                proximoDialogo(dialogosFinalErrado);
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

    
    void InicioDialogo(string[] mensagem)
    {
        dialogoIndex = 0;
        StartCoroutine(MostrarDialogo(mensagem));
        inicioConversa = true;
        conversando = true;
        passiente.gameObject.SetActive(true);
        fadeIn = true;
        
    }

    void proximoDialogo(string[] mensagem)
    {
        dialogoIndex++;

        if(dialogoIndex < mensagem.Length)
        {
            StartCoroutine(MostrarDialogo(mensagem));
        }
        else
        {
            dialogoIndex = 0;
            inicioConversa = false;
            passiente.gameObject.SetActive(false);
            conversando = false;
            fadeOut = true;
            final = false;
            balao[0].gameObject.SetActive(true);
            balao[1].gameObject.SetActive(false);  
            DialogoTerminou?.Invoke();

        }
    }


    IEnumerator MostrarDialogo(string[] mensagem)
    {
        texto.text = "";
        bool pular = false;
        if(conversando)
        {
            h = !h;
            balao[0].gameObject.SetActive(h);
            h = !h;
            balao[1].gameObject.SetActive(h);
            h = !h;
        }

        //Botar audio play aqui
        foreach (char letter in mensagem[dialogoIndex])
        {   
            yield return new WaitForSeconds(0.1f);
            if(pular == false)
            {
                texto.text += letter;
                if(Input.GetButton("Fire1"))
                {
                    texto.text = "";
                    texto.text = mensagem[dialogoIndex];
                    pular = true;
                }
            }
           
            
            
        }
    }
}
