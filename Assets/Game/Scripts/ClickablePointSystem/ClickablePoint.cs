using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickablePoint : MonoBehaviour, IPointerClickHandler
{
    private bool isClicked = false;
    [SerializeField] bool isCorrect;
    public event Action<ClickablePoint> AttemptResult;
    public bool IsCorret => isCorrect;
    public void Reset()
    {
        isClicked = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isClicked) return;
        //TODO: MOSTRAR
        AttemptResult?.Invoke(this);
        isClicked = true;

    }
}

