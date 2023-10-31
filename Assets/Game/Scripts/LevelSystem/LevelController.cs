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
    private bool DiagnosticoCorretoContaminado = false;
    private FichaController fichaController;

    [SerializeField] private Button button_finalizarExpediente;
    private List<IObjective> objectiveMinigames = new();
    private IObjective fichaObjective; 
    public event Action LevelComplete = delegate {};

    public bool DiagnosticoEstaCorreto() 
    {
        return fichaController.JogadorEscolheuContaminado == DiagnosticoCorretoContaminado;
    }


    void Start()
    {
        FindObjectiveMinigames();
        fichaObjective = FindObjectOfType<FichaController>().GetComponent<IObjective>();
        fichaController = FindObjectOfType<FichaController>();

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
        Debug.Log("algo mudou");
        if(EveryObjectiveComplete()) 
        {
            FinishMinigames();
        }

    }



    public void FinishMinigames() 
    {
        LevelComplete?.Invoke();
        button_finalizarExpediente.gameObject.SetActive(true);
    }



}
