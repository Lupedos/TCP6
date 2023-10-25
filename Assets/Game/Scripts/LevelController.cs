using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private List<IObjective> objectiveMinigames = new();
    private IObjective fichaObjective; 
    void Start()
    {
        FindObjectiveMinigames();
        fichaObjective = FindObjectOfType<FichaController>().GetComponent<IObjective>();

    }

    private void FindObjectiveMinigames() {
        objectiveMinigames.Clear();
        Minigame[] minigames = FindObjectsOfType<Minigame>();
        foreach(Minigame minigame in minigames) 
        {
            objectiveMinigames.Add(minigame.GetComponent<IObjective>());
        }

        
    }
    


    public bool LevelIsCompleted() 
    {
        foreach(Minigame minigame in objectiveMinigames) 
        {
            if(!minigame.Complete) return false;
        }
        if(!fichaObjective.Complete) return false;

        return true;


    }

}


public class Minigame : MonoBehaviour, IObjective
{
    public bool Complete { get; set ; } = false;

    public event Action OnComplete = delegate {};

    public void SetComplete() 
    {
        Complete = true;
        OnComplete?.Invoke();
    }
}

public interface IObjective {
    public bool Complete {get;  set;}
    public  event Action OnComplete;

}