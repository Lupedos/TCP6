using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrecisionClick : MonoBehaviour
{
    [SerializeField] private Scrollbar scrollbar;

    [SerializeField] private float speed = 0.5f;

    public bool isRunning = true;

    public float GetSinValue()
    {
        return Mathf.Sin(speed * Time.time) / 2 + 0.5f;
    }

    private void Start()
    {
        StartLoop();

    }
    private void Update()
    {
        if (isRunning) scrollbar.value = GetSinValue();
        else return;

        if (Input.GetMouseButtonDown(0))
        {
            isRunning = false;
            if (IsPointerInRange()) Debug.Log("acertou");
            else Debug.Log("errou");
        }

    }


    public void StartLoop()
    {
        //if(!isRunning) return;
        //DOTween.To(() => scrollbar.value, x => scrollbar.value = x, 1, 1).SetEase(Ease.InOutExpo).OnComplete(() =>
        //{


        //});

    }

    public bool IsPointerInRange()
    {
        return scrollbar.value > 0.5f - 0.15f && scrollbar.value < 0.5f + 0.15f;
    }

}


