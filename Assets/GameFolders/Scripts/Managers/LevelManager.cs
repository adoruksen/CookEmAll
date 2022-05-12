using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static GameState gameState;
    public LevelAsset levelAsset;

    private void Start()
    {
        CreateLevel();
    }
    void CreateLevel()
    {
        if (GameManager.Level <= levelAsset.levels.Length)
        {
            GameObject levelBorder = Instantiate(levelAsset.levels[GameManager.Level - 1]);
        }
        else
        {
            GameObject levelBorder = Instantiate(levelAsset.levels[Random.Range(0, levelAsset.levels.Length)]);
        }
    }

}



