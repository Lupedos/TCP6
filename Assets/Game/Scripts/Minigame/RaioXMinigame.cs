using Game;
using System;
using UnityEngine;

public class RaioXMinigame : Minigame
{

    //contagem de pontos de click corretos
    [SerializeField] ClickablePointController clickablePointController;
    public ClickablePointController ClickablePointController => clickablePointController;

    private void Start()
    {
        clickablePointController = GetComponent<ClickablePointController>();

    }


}
