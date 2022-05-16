using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public static GameState gameState;
    public LevelAsset levelAsset;
    public LevelRules levelRules;

    public int MoveCounter => levelRules.moveCounter[GameManager.Level-1];
    void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        CreateLevel();
    }
    void CreateLevel()
    {
        if (GameManager.Level <= levelAsset.levels.Length)
        {
            Instantiate(levelAsset.levels[GameManager.Level - 1]);
            DuringGamePanelController.instance.MoveCounterSetter(MoveCounter);

        }
        else
        {
            GameObject myLevel =Instantiate(levelAsset.levels[Random.Range(0, levelAsset.levels.Length)]);
            int myIndex = Array.IndexOf(levelAsset.levels, myLevel);
            DuringGamePanelController.instance.MoveCounterSetter(myIndex);
        }
    }

}



