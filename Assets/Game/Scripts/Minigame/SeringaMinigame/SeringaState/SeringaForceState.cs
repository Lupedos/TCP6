using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SeringaForceState : State
{    
    // private SeringaAnimationState currectAnimation = SeringaAnimationState.STANDBY;
    [SerializeField] private SeringaMinigameController seringaController;
    private State directionState;
    [SerializeField] private Image machucadoImage;
    private void Start()
    { 
        directionState = GetComponent<SeringaDirectionState>();
        seringaController = GetComponent<SeringaMinigameController>();
    }


    public override void StateStart()
    {
        seringaController.SetMessage("Força.");

        seringaController.PrecisionClick.SetActive(true);
        seringaController.PrecisionClick.IsClickOnRange += IsClickOnRange;

    }

    public override void StateUpdate()
    {        

    }

    public override void StateExit()
    {
        seringaController.PrecisionClick.SetActive(false);
        seringaController.PrecisionClick.IsClickOnRange -= IsClickOnRange;
    }

        private void IsClickOnRange(bool value)
    {
        //MANDOU PARAR O MINIGAME E ACERTOU BUNITO
        if(value) 
        {
            StartCoroutine(CorrectClickAnim());
        }
        else 
        {
            StartCoroutine(WrongClickAnim());
        }
    }

    private IEnumerator CorrectClickAnim() 
    {
        Vector3 seringaObjectTargetPos = seringaController.SeringaObject.transform.rotation*Vector3.up*8;
        seringaController.SeringaObject.DOLocalMove(seringaObjectTargetPos, 1);
        seringaController.SetMessage("Muito bem");
        seringaController.PrecisionClick.SetActive(false);
        
        yield return new WaitForSeconds(1);
        seringaController.SetComplete();
        seringaController.SeringaObject.GetComponent<Image>().DOFade(0, 1).OnComplete(() =>
        {
            machucadoImage.DOFade(1, 1).SetEase(Ease.OutCirc);

        });
        seringaController.SeringaObjectViewable.SetActive(false);

    }

    private IEnumerator WrongClickAnim() 
    {

        seringaController.PrecisionClick.SetActive(false);
        yield return new WaitForSeconds(1);
        stateController.SetState(directionState);

    }




}

