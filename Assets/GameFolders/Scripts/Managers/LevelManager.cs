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
        private int levelNumber;
        public int LevelNumber => levelNumber;

        //public int MoveCounter => levelRules.moveCounter[GameManager.Level-1];
        void Awake()
        {
            if (instance != null && instance != this)
                Destroy(this.gameObject);
            else
            {
                instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            //instance = this;
            CreateLevel();
        }

        //void OnEnable()
        //{
        //    SceneLoadLayer.instance.SceneLoadAnimation();
        //}


        private void CreateLevel()
        {
            if (GameManager.Level <= levelAsset.levels.Length)
            {
                var level = Instantiate(levelAsset.levels[GameManager.Level - 1]);
                //DuringGamePanelController.instance.MoveCounterSetter(GameManager.Level-1);
                //RecipeController.instance.singleRecipes.Clear();
                //for (var i = 0; i < level.transform.GetChild(0).childCount; i++)
                //{
                //    RecipeController.instance.singleRecipes.Add(level.transform.GetChild(0).GetChild(i).GetChild(1).GetComponent<SingleRecipe>());
                //}

                //levelNumber = GameManager.Level +1;

            }
            else
            {
                var randomNumber = Random.Range(0, levelAsset.levels.Length);
                var myLevel =Instantiate(levelAsset.levels[randomNumber]);
                //DuringGamePanelController.instance.MoveCounterSetter(levelRules.moveCounter[randomNumber]);
                //RecipeController.instance.singleRecipes.Clear();
                //for (var i = 0; i < myLevel.transform.GetChild(0).childCount; i++)
                //{
                //    RecipeController.instance.singleRecipes.Add(myLevel.transform.GetChild(0).GetChild(i).GetChild(1).GetComponent<SingleRecipe>());
                //}

                //levelNumber = randomNumber == 1 ? randomNumber + 1 : randomNumber;
            }
        }

    }
}



