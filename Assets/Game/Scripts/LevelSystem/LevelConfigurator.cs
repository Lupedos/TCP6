using Game.Table;
using System;
using UnityEngine;

public class LevelConfigurator : MonoBehaviour
{
    [SerializeField] private TableController tableController;
    [SerializeField] private SeringaMinigameController seringaMinigame;

    [SerializeField] private LevelConfig config;

    public LevelConfig Config { get { return config; } }
    private Calendary calendary;
    private void Start()
    {
        tableController.SetActiveTableObject(TableObjectType.SERINGA, config.SeringaOn);
        tableController.SetActiveTableObject(TableObjectType.MICROSCOPIO, config.MicroscopioOn);
        tableController.SetActiveTableObject(TableObjectType.RAIO_X, config.RaioXOn);

        ConfigurarSeringa();
        TentarAnimarCalendario();
    }

    private void TentarAnimarCalendario()
    {
        calendary = FindObjectOfType<Calendary>();
        if (config.CenaTutorial) calendary.PlayAnimationEntry();

    }

    private void ConfigurarSeringa()
    {
        if(config.MachudoSeringaGrande) 
        {
             seringaMinigame.Machucado.localScale = Vector3.one*1; 
        }
        else
        {
            seringaMinigame.Machucado.localScale = Vector3.one * 0.3f;

        }
    }

}
