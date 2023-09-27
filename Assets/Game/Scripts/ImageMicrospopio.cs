using Game.Table;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class ImageMicrospopio : MonoBehaviour, IActivable
{
    private List<ClickablePoint> clicablePoints;
    private int correntClickCount = 0;
    private int wrongClickCount = 0;

    private int TotalClick => correntClickCount + wrongClickCount;
    public bool TryedAllClickablePoints => TotalClick == clicablePoints.Count;

    public bool IsActive { get; private set; } = false;
    public event Action<bool> Activate;

    //contagem de pontos de click corretos
    public int GetCorrectPointCount()
    {
        return (from point in clicablePoints
                where point.IsCorret
                select point).Count();
    }
    
    //acertou todos ja?
    public bool GotThemAllright()
    {
        return (GetCorrectPointCount() == correntClickCount);
    }

    private void Start()
    {
        clicablePoints = GetComponentsInChildren<ClickablePoint>().ToList();

        SubscribeOnClickPoints();

    }

    public void SubscribeOnClickPoints()
    {
        foreach (var point in clicablePoints)
        {
            point.AttemptResult += OnClickPointAttemptResult;
        }
    }

    private void OnClickPointAttemptResult(ClickablePoint point)
    {
        if (point.IsCorret) correntClickCount++;
        else wrongClickCount++;
        UnsubscribeOnClickPoint(point);
        Debug.Log("Acertou todos ja?: "+GotThemAllright());


    }



    private void UnsubscribeOnClickPoint(ClickablePoint point)
    {
        point.AttemptResult -= OnClickPointAttemptResult;

    }

    public void SetActive(bool active)
    {
        IsActive = active;
        Activate?.Invoke(active);

    }



}
