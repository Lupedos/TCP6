using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class ClickablePointController : MonoBehaviour, IClickableInterfaceEvents
{
    private ClickablePoint[] clicablePoints;
    private IObjective iObjective;
    private int correntClickCount = 0;
    private int wrongClickCount = 0;

    public event Action<int> CorrectClick;
    public event Action<int> WrongClick;
    public event Action OnGotThemAllRight;
    public event Action OnTryedAllPoints;
    

    private int TotalClick => correntClickCount + wrongClickCount;
    public bool TryedAllPoints => (TotalClick == clicablePoints.Length);
    //acertou todos ja?
    public bool GotThemAllRight => (GetCorrectPointCount() == correntClickCount);

    void Awake()
    {
        iObjective = GetComponent<IObjective>();
        clicablePoints = GetComponentsInChildren<ClickablePoint>();

    }

    private void Start()
    {

        SubscribeOnClickPoints();

    }



    public void SubscribeOnClickPoints()
    {
        foreach (var point in clicablePoints)
        {
            point.AttemptResult += OnClickPointAttemptResult;
        }
    }

    public int GetCorrectPointCount()
    {
        return (from point in clicablePoints
                where point.IsCorret
                select point).Count();
    }

    private void OnClickPointAttemptResult(ClickablePoint point)
    {
        if (point.IsCorret)
        {
            correntClickCount++;
            CorrectClick?.Invoke(correntClickCount);
        }
        else
        {
            wrongClickCount++;
            WrongClick?.Invoke(wrongClickCount);
        }
        UnsubscribeOnClickPoint(point);
        if (GotThemAllRight) OnGotThemAllRight?.Invoke();
        if (TryedAllPoints) OnTryedAllPoints?.Invoke();


    }


    private void UnsubscribeOnClickPoint(ClickablePoint point)
    {
        point.AttemptResult -= OnClickPointAttemptResult;

    }

    public void Subscription()
    {
        
    }

    public void Unsubscription()
    {

    }
}



