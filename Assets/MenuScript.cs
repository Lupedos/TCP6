using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{


    public void Jogar()
    {
        SceneManager.LoadScene(4);
    }
    public void Creditos()
    {
        SceneManager.LoadScene(3);
    }
    public void Info()
    {
        SceneManager.LoadScene(2);
    }
    public void Niveis()
    {
        SceneManager.LoadScene(1);
    }

    public void Sair()
    {
        Application.Quit();
    }

    public void Config()
    {

    }

    public void Inicio()
    {
        SceneManager.LoadScene(0);
    }

}
