using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeringaAnimationSet : MonoBehaviour
{
    [SerializeField] private GameObject seringa;
    [SerializeField] Scrollbar scrollbar;
    [SerializeField] private float seringaMovementScale = 1f;
    private Vector3 initialPos;
    private void Start()
    { 
        initialPos = transform.position;
        scrollbar.onValueChanged.AddListener(OnScrollbarChange);
    }

    private void OnScrollbarChange(float arg0)
    {
        seringa.transform.position = initialPos + seringaMovementScale* Vector3.right* (arg0 - 0.5f);
    }
}
