using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ImagemDialogoController : MonoBehaviour
{
    [SerializeField] private Image image_balaoFundo;
    [SerializeField] private Image image;

    [SerializeField] private List<ImagensDialogo> imagensDialogos;

    private DialogoScript dialogoScript;

    private void Start()
    {
        dialogoScript = FindObjectOfType<DialogoScript>();
        dialogoScript.QuandoMostraDialogo.AddListener(QuandoMostraDialogo);

        image_balaoFundo.DOFade(0, 0);
        image.DOFade(0, 0);
    }

    private void OnDestroy()
    {
        dialogoScript.QuandoMostraDialogo.RemoveListener(QuandoMostraDialogo);

    }

    public void QuandoMostraDialogo(int index)
    {
        foreach(ImagensDialogo imagensDialogo in imagensDialogos)
        {
            if(imagensDialogo.Index == index)
            {
                image.DOFade(0, 0);
                image.sprite = imagensDialogo.Sprite;
                image.DOFade(1, 1);
                image_balaoFundo.DOFade(1, 1);
                return;
            }
        }

        //image.DOFade(0, 0);
    }

}
