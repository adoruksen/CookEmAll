using UnityEngine;
using Random = UnityEngine.Random;

namespace CookEmAll.Managers
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager instance;
        public static GameState gameState;
        public LevelAsset levelAsset;
        void Awake()
        {
            instance = this;
            CreateLevel();
        }

        private void CreateLevel()
        {
            if (GameManager.Level <= levelAsset.levels.Length)
            {
                Instantiate(levelAsset.levels[GameManager.Level - 1]);
            }
            else
            {
                var randomNumber = Random.Range(0, levelAsset.levels.Length);
                Instantiate(levelAsset.levels[randomNumber]);
            }
        }
    }
}



