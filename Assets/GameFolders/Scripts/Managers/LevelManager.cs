using System;
using Assets.GameFolders.Scripts.Gameplay.Recipe_System;
using Assets.GameFolders.Scripts.UI;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.GameFolders.Scripts.Managers
{
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
                GameObject level = Instantiate(levelAsset.levels[GameManager.Level - 1]);
                DuringGamePanelController.instance.MoveCounterSetter(MoveCounter);
                //RecipeController.instance.singleRecipes.Clear();
                //for (int i = 0; i < level.transform.childCount; i++)
                //{
                //    RecipeController.instance.singleRecipes.Add(level.transform.GetChild(i).gameObject);

                //}

            }
            else
            {
                GameObject myLevel =Instantiate(levelAsset.levels[Random.Range(0, levelAsset.levels.Length)]);
                int myIndex = Array.IndexOf(levelAsset.levels, myLevel);
                DuringGamePanelController.instance.MoveCounterSetter(myIndex);
            }
        }

    }
}



