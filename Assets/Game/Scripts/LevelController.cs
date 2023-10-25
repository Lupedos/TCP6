using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 1. Classe que observe quando algum objetivo foi cumprido.
/// 2. Em seguida, verifica se todos foram cumpridos.
/// 3. Se todos foram cumpridos, dispara um evento sinalizando que todos os objetivos foram cumpridos (EveryObjectiveComplete)
/// </summary>
public class LevelController : MonoBehaviour
{
    [SerializeField] private Button button_finalizarExpediente;
    private List<IObjective> objectiveMinigames = new();
    private IObjective fichaObjective; 
    public event Action LevelComplete = delegate {};


    void Start()
    {
        FindObjectiveMinigames();
        fichaObjective = FindObjectOfType<FichaController>().GetComponent<IObjective>();

        foreach(IObjective iObjective in objectiveMinigames) {
            iObjective.OnComplete += AnyObjectiveComplete;
        }
        fichaObjective.OnComplete += AnyObjectiveComplete;



        button_finalizarExpediente.gameObject.SetActive(false);


    }

    void OnDestroy()
    {
                foreach(IObjective iObjective in objectiveMinigames) {
            iObjective.OnComplete -= AnyObjectiveComplete;
        }
        fichaObjective.OnComplete -= AnyObjectiveComplete;
    }

    private void FindObjectiveMinigames() {
        objectiveMinigames.Clear();
        Minigame[] minigames = FindObjectsOfType<Minigame>();
        foreach(Minigame minigame in minigames) 
        {
            objectiveMinigames.Add(minigame.GetComponent<IObjective>());
        }

        
    }
    


    public bool EveryObjectiveComplete() 
    {
        foreach(Minigame minigame in objectiveMinigames) 
        {
            if(!minigame.Complete) return false;
        }
        if(!fichaObjective.Complete) return false;

        return true;


    }

    public void AnyObjectiveComplete() {
        if(EveryObjectiveComplete()) 
        {
            LevelComplete?.Invoke();
            button_finalizarExpediente.gameObject.SetActive(true);
        }

    }

}
