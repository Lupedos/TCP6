using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickablePoint : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] bool isCorrect;
    public event Action<ClickablePoint> AttemptResult;
    public bool IsCorret => isCorrect;
    public bool marked { get; private set; } = false;
    public void Reset()
    {
        marked = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        marked = !marked;
        //TODO: MOSTRAR
        AttemptResult?.Invoke(this);

    }
}

