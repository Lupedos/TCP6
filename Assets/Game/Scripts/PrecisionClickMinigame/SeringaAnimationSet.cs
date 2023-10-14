using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeringaAnimationSet : MonoBehaviour
{
    [SerializeField] private RectTransform seringa;
    [SerializeField] Scrollbar scrollbar;
    [SerializeField] private float seringaMovementScale = 1f;
    [SerializeField] private float minMaxMotionCut = 0.5f;
    private Vector3 seringaInitPos;
    private void Start()
    { 
        seringaInitPos = seringa.position;
        scrollbar.onValueChanged.AddListener(OnScrollbarChange);
    }

    private void OnScrollbarChange(float arg0)
    {
        seringa.position = seringaInitPos + seringaMovementScale* Vector3.right* (arg0 - minMaxMotionCut);
    }

    

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        if(seringaInitPos == Vector3.zero)
            Gizmos.DrawLine(seringa.position - seringaMovementScale*Vector3.right, seringa.position + seringaMovementScale*Vector3.right);
        else
            Gizmos.DrawLine(seringaInitPos - seringaMovementScale*Vector3.right, seringaInitPos + seringaMovementScale*Vector3.right);

            


















                                                            









    }

}
