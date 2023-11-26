using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelDataContainer : MonoBehaviour
{
    public List<Dia> Dias = new();

    void Start()
    {
        SaveData(0, true);
    }


    public void SaveData(int dia, bool completouTodos)
    {

        UpdateFile();
    }

    public void UpdateFile()
    {
        string data = JsonUtility.ToJson(Dias);
        File.WriteAllText("LevelData.json", data);
        Debug.Log("LevelData.json");
    }


}


[Serializable]
public class Dia
{
    public List<Nivel> niveis = new List<Nivel>();

}


[Serializable]
public class Nivel
{
    public int buildIndex;
    public bool jaJogou;
    public bool Acertou;
}
