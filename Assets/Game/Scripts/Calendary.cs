using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Calendary : MonoBehaviour
{
     private TMP_Text text_day;
    private Animator animator;
    private void Awake()
    {
        text_day = GetComponentInChildren<TMP_Text>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        //int currentScene = SceneManager.GetActiveScene().buildIndex - 3;
        //text_day.SetText(currentScene.ToString());
    }

    public void PlayAnimationEntry()
    {
        animator.Play(Animator.StringToHash("CalendaryEnter"));

    }


}
