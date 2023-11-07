using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class ClickablePointController : MonoBehaviour
{
    private ClickablePoint[] clicablePoints;
    private IObjective iObjective;
    private int correntClickCount = 0;
    private int wrongClickCount = 0;

    public event Action<int> OnClick;
    public event Action OnGotThemAllRight;
    public event Action OnTryedAllPoints;

    private int TotalClick => correntClickCount + wrongClickCount;
    public bool TryedAllPoints => (TotalClick == clicablePoints.Length);
    //Marcou todos corretamente:
    /// <summary>
    /// Marcou todos corretamente?
    /// </summary>
    public bool GotThemAllRight
    {
        get
        {
            if (wrongClickCount > 0) return false;
            return (GetMarkedCorrectPointCount() == correntClickCount);
        }
    }

    void Awake()
    {
        iObjective = GetComponent<IObjective>();

    }

    public void Initialize()
    {
        clicablePoints = GetComponentsInChildren<ClickablePoint>();
        SubscribeOnClickPoints();
    }

    public void OnDestroy()
    {
        UnsubscribeOnClickPoints();
    }



    public void SubscribeOnClickPoints()
    {
        foreach (var point in clicablePoints)
        {
            point.AttemptResult += OnClickPointAttemptResult;
        }
    }
    public void UnsubscribeOnClickPoints()
    {
        foreach (var point in clicablePoints)
        {
            point.AttemptResult -= OnClickPointAttemptResult;
        }
    }





    private void OnClickPointAttemptResult(ClickablePoint point)
    {
        OnClick?.Invoke(GetClickablePointMarked());
        UpdateCorrectAndWrongCount();

    }


    public int GetMarkedCorrectPointCount()
    {
        return (from point in clicablePoints
                where point.IsCorret
                select point).Count();
    }
    public int GetmarkedWrongPointCount()
    {
        return (from point in clicablePoints
                where !point.IsCorret
                select point).Count();
    }
    public int GetClickablePointMarked()
    {
        int count = 0;
        foreach(var point in clicablePoints)
        {
            if(point.marked) count++;
        }
        return count;
    }

    private void UpdateCorrectAndWrongCount()
    {
        correntClickCount = 0;
        wrongClickCount = 0;
        foreach(var point in clicablePoints)
        {
            if (!point.marked) continue;
            if (point.IsCorret) correntClickCount++;
            if (!point.IsCorret) wrongClickCount++;

        }
    }



}



