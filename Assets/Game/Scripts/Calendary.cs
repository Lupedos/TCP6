using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Calendary : MonoBehaviour
{
     private TMP_Text text_day;

    private void Awake()
    {
        text_day = GetComponentInChildren<TMP_Text>();
    }
    void Start()
    {
        //int currentScene = SceneManager.GetActiveScene().buildIndex - 3;
        //text_day.SetText(currentScene.ToString());

    }


}
