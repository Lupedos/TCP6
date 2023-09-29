using Game.Table;
using System;
using UnityEngine;


public class ImageMicrospopio : MonoBehaviour, IActivable
{


    public bool IsActive { get; private set; } = false;

    public event Action<bool> Activate;

    //contagem de pontos de click corretos
    [SerializeField] ClickablePointController clickablePointController;
    public ClickablePointController ClickablePointController  => clickablePointController; 

    private void Start()
    {
        clickablePointController = GetComponent<ClickablePointController>();

    }


    public void SetActive(bool active)
    {
        IsActive = active;
        Activate?.Invoke(active);

    }





}
