using DG.Tweening;
using Game.Table;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrecisionClick : MonoBehaviour, IActivable
{
    [SerializeField] private Scrollbar scrollbar;
    [SerializeField] private RectTransform range;

    [SerializeField] private float minSpeed = 1;
    private float speedMultiplier  = 1;
    public event Action<bool> Activate;

    public bool IsActive { get; private set;}

    public bool IsPointerInRange()
    {
        //se o ponteiro do slider (região laranja) está situado dentro da faixa de acerto( região verde)
        return scrollbar.value > 0.5f - range.localScale.x/2  && scrollbar.value < 0.5f + range.localScale.x/2;
    }
    public float GetSinValue()
    {
        return Mathf.Sin(minSpeed * speedMultiplier * Time.time) / 2 + 0.5f;
    }

    private void Update()
    {

        if (IsActive) scrollbar.value = GetSinValue();
        else return;

        if (Input.GetMouseButtonDown(0))
        {
            if (IsPointerInRange()) Debug.Log("acertou");
            else Debug.Log("errou");
        }

    }



    public void SetActive(bool active)
    {
        IsActive = active;
        Activate?.Invoke(active);

    }

    //speedMultiplier: beetween 1 and 2;
    //barWidhtRange: beetween 0.1f to 0.5f
    public void StartLoopMovement(float speedMultiplier, float barWidthRange) 
    {
        this.speedMultiplier = speedMultiplier;
        range.localScale.Set(barWidthRange, range.localScale.y, range.localScale.z);

    }


}


