using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public static void SaveLevelReleased(int level)
    {
        PlayerPrefs.SetInt("LevelReleased", level);
    }

    public static int GetLevelReleased()
    {
        if (PlayerPrefs.HasKey("LevelReleased"))
            return PlayerPrefs.GetInt("LevelReleased");

        else return 3;
    }





}
