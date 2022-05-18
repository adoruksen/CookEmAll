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
            SceneLoadLayer.instance.SceneLoadAnimation();
            CreateLevel();
        }
        void CreateLevel()
        {
            if (GameManager.Level <= levelAsset.levels.Length)
            {
                GameObject level = Instantiate(levelAsset.levels[GameManager.Level - 1]);
                DuringGamePanelController.instance.MoveCounterSetter(GameManager.Level-1);
                RecipeController.instance.singleRecipes.Clear();
                for (int i = 0; i < level.transform.GetChild(0).childCount; i++)
                {
                    RecipeController.instance.singleRecipes.Add(level.transform.GetChild(0).GetChild(i).GetChild(0).GetComponent<SingleRecipe>());
                }

            }
            else
            {
                var randomNumber = Random.Range(0, levelAsset.levels.Length);
                GameObject myLevel =Instantiate(levelAsset.levels[randomNumber]);
                DuringGamePanelController.instance.MoveCounterSetter(levelRules.moveCounter[randomNumber]);
                RecipeController.instance.singleRecipes.Clear();
                for (int i = 0; i < myLevel.transform.GetChild(0).childCount; i++)
                {
                    RecipeController.instance.singleRecipes.Add(myLevel.transform.GetChild(0).GetChild(i).GetChild(0).GetComponent<SingleRecipe>());
                }
            }
        }

    }
}



