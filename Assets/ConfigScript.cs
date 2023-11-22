using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfigScript : MonoBehaviour
{
    public static ConfigScript instancia = null ;
    private bool aberto = false;
    public GameObject menuConfig;
    private void Awake()
    {
        if (instancia == null) instancia = this;
        else if (instancia != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public void Voltar()
  {
    SceneManager.LoadScene(0);
    menuConfig.gameObject.SetActive(false);
    aberto = false;
  }
  void Update()
  {
     
    if(Input.GetKeyDown(KeyCode.Escape))
    {
      Configuracoes();
     
    }
  }
  public void Configuracoes()
  {
    aberto = !aberto;
    if(aberto)
    {
        menuConfig.gameObject.SetActive(true);
    }
    else
    {
        menuConfig.gameObject.SetActive(false);
    }
    
  }
  public void Sair()
  {
    Application.Quit();
  }
}
