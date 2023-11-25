using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;

public class DialogoScript : MonoBehaviour
{
    public float velocidadeCaracteres = 0.001f;
    public string[] dialogos;
    public string[] dialogosFinalCerto;
    public string[] dialogosFinalErrado;
    public bool ganhou;
    public Image[] pessoa;
    public Image[] balao;
    public int dialogoIndex;
    public TextMeshProUGUI texto;
    public bool inicioConversa;
    public AudioClip balaoFalaClip;
    public bool medicafalando;
    public bool conversando;
    public bool final;
    [SerializeField] private CanvasGroup myTextUI;
    private bool fadeIn = false;
    private bool fadeOut = false;
    public bool h = false;
    public bool mostrarLogoODialogo = false;
    public bool printandoTextoDoDialogo = false;

    [Space(20)]
    public UnityEvent DialogoIniciou;
    public UnityEvent DialogoTerminou;
    //Int: index do dialogo mostrando;
    public UnityEvent<int> QuandoMostraDialogo;


    void Start()
    {
        inicioConversa = false;
        fadeOut = true;
        pessoa[1].gameObject.SetActive(false);
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
        if (printandoTextoDoDialogo == true)
        {
            if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space))
            {
                mostrarLogoODialogo = true;
            }
        }


        if (Input.GetButtonDown("Fire1") && conversando
        || Input.GetKeyDown(KeyCode.Space) && conversando)
        {

            if (!inicioConversa)
            {
                IniciarDialogoInicial();
            }
            else if (texto.text == dialogos[dialogoIndex] && conversando)
            {
                proximoDialogo(dialogos);
            }

        }

        if (final && ganhou)
        {
            if (!inicioConversa)
                InicioDialogo(dialogosFinalCerto);
            balao[2].gameObject.SetActive(true);

            if (Input.GetButtonDown("Fire1") && texto.text == dialogosFinalCerto[dialogoIndex]
            || Input.GetKeyDown(KeyCode.Space) && texto.text == dialogosFinalCerto[dialogoIndex])
            {
                proximoDialogo(dialogosFinalCerto);

            }


        }
        else if (final && ganhou == false)
        {
            if (!inicioConversa) InicioDialogo(dialogosFinalErrado);
            balao[2].gameObject.SetActive(true);
            if (Input.GetButtonDown("Fire1") && texto.text == dialogosFinalErrado[dialogoIndex]
            || Input.GetKeyDown(KeyCode.Space) && texto.text == dialogosFinalErrado[dialogoIndex])
            {
                proximoDialogo(dialogosFinalErrado);

            }
        }

        if (fadeIn)
        {
            if (myTextUI.alpha < 1)
            {
                myTextUI.alpha += Time.deltaTime;
                if (myTextUI.alpha >= 1)
                {
                    fadeIn = false;
                }
            }
        }
        if (fadeOut)
        {
            if (myTextUI.alpha >= 0)
            {
                myTextUI.alpha -= Time.deltaTime;
                if (myTextUI.alpha == 0)
                {
                    fadeOut = false;
                }
            }
        }




        //if (mostrandoTextoDoDialogo == true)
        //{


        //}



    }


    void InicioDialogo(string[] mensagem)
    {
        dialogoIndex = 0;
        StartCoroutine(MostrarDialogo(mensagem));
        inicioConversa = true;
        conversando = true;
        if (final)
        {
            pessoa[1].gameObject.SetActive(true);
            pessoa[0].gameObject.SetActive(false);
        }
        else
        {
            pessoa[0].gameObject.SetActive(true);
        }
        fadeIn = true;
        fadeOut = false;

    }

    void proximoDialogo(string[] mensagem)
    {
        dialogoIndex++;
        QuandoMostraDialogo?.Invoke(dialogoIndex);
        if (dialogoIndex < mensagem.Length)
        {
            StartCoroutine(MostrarDialogo(mensagem));
        }
        else
        {
            dialogoIndex = 0;
            inicioConversa = false;
            if (final)
            {
                pessoa[1].gameObject.SetActive(false);
            }



            conversando = false;
            fadeOut = true;
            final = false;
            balao[0].gameObject.SetActive(false);
            balao[1].gameObject.SetActive(true);
            DialogoTerminou?.Invoke();

        }
    }


    IEnumerator MostrarDialogo(string[] mensagem)
    {
        printandoTextoDoDialogo = true;
        SoundEffectPlayerManager.Instance.PlaySfx(balaoFalaClip);
        texto.text = "";
        if (conversando && !final && !medicafalando)
        {
            h = !h;
            balao[0].gameObject.SetActive(h);
            h = !h;
            balao[1].gameObject.SetActive(h);
            h = !h;
        }



        foreach (char letter in mensagem[dialogoIndex])
        {
            if (mostrarLogoODialogo == false)
            {
                texto.text += letter;
                yield return new WaitForSeconds(velocidadeCaracteres);

            }
            else
            {
                texto.SetText(mensagem[dialogoIndex]);
                printandoTextoDoDialogo = false;
                mostrarLogoODialogo = false;
                yield return null;
                break;
            }




        }






    }


}
