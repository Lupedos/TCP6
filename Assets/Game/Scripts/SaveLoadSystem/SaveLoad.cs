using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    //public static void SaveLevelReleased(int level)
    //{
    //    PlayerPrefs.SetInt("LevelReleased", level);
    //}

    //public static int GetLevelReleased()
    //{
    //    if (PlayerPrefs.HasKey("LevelReleased"))
    //        return PlayerPrefs.GetInt("LevelReleased");

    //    else return 3;
    //}
    public static int GetLevelCompleted()
    {
        if (PlayerPrefs.HasKey("LevelCompleted"))
            return PlayerPrefs.GetInt("LevelCompleted");

        else return 0;
    }



    public static void SaveLevelCompleted(int level)
    {

        if(level >= GetLevelCompleted())
            PlayerPrefs.SetInt("LevelCompleted", level);
        Debug.Log("Save complete level: " + level);

    }



}
