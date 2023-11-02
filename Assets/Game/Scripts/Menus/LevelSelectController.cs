using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectController : MonoBehaviour
{
    private List<Button> levelSelectButtons;


    private List<Button> FindButtonsChilds()
    {
        return GetComponentsInChildren<Button>().ToList();
    }

    private void Start()
    {
        levelSelectButtons = FindButtonsChilds();
        LiberarLevelsDesbloqueados();
    }





    private void LiberarLevelsDesbloqueados()
    {

        for (int i = 0; i < levelSelectButtons.Count; i++)
        {
            if(i < SaveLoad.GetLevelReleased())
            {
                levelSelectButtons[i].interactable = true;

            } else
            {
                levelSelectButtons[i].interactable = false;

            }
        }

    }




}
