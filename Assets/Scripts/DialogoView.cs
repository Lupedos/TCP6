using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DialogoView : MonoBehaviour
{
    private DialogoScript dialogoScript;
   [SerializeField] private CanvasGroup canvasGroup;

    void Awake()
    {
        dialogoScript = GetComponent<DialogoScript>();

    }
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;

        dialogoScript.DialogoIniciou.AddListener(OnDialogoInicia);
        dialogoScript.DialogoTerminou.AddListener(OnDialogoTermina);

        
    }

    void OnDestroy()
    {
        dialogoScript.DialogoIniciou.RemoveListener(OnDialogoInicia);
        dialogoScript.DialogoTerminou.RemoveListener(OnDialogoTermina);
    }



    public void OnDialogoInicia() 
    {
        canvasGroup.DOFade(1, 0.5f);
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;

    }

    public void OnDialogoTermina() 
    {
        canvasGroup.DOFade(0, 0.5f);
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }

}
