using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogoScript : MonoBehaviour
{
    public string[] dialogos;
    public int dialogoIndex;
    public TextMeshProUGUI texto;
    public bool inicioConversa; 
    void Start()
    {
        inicioConversa = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(!inicioConversa)
            {
                InicioDialogo();
            }
            else if (texto.text == dialogos[dialogoIndex])
            {
                proximoDialogo();
            }
        }
        
    }

    
    void InicioDialogo()
    {
        dialogoIndex = 0;
        StartCoroutine(MostrarDialogo());
        inicioConversa = true; 
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
        }
    }


    IEnumerator MostrarDialogo()
    {
        texto.text = "";
        bool pular = false; 
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
