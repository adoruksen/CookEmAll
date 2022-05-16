using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static int level;
    public static int Level
    {
        get
        {
            if (!PlayerPrefs.HasKey("level"))
            {
                return 1;
            }
            return PlayerPrefs.GetInt("level");
        }
        set
        {
            level = value;
            PlayerPrefs.SetInt("level", level);
        }
    }

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("level"))
        {
            PlayerPrefs.SetInt("level", 1);
        }
    }
}
