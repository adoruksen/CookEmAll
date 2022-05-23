using System.Collections.Generic;
using System.Linq;
using Assets.GameFolders.Scripts.Managers;
using Assets.GameFolders.Scripts.UI;
using UnityEngine;

namespace Assets.GameFolders.Scripts.Gameplay.Recipe_System
{
    public class RecipeController : MonoBehaviour
    {
        public static RecipeController instance;
        public List<SingleRecipe> singleRecipes;
        private void Awake()
        {
            instance = this;
        }

        void Start()
        {
            singleRecipes.Clear();
            for (var i = 0; i < LevelController.instance.recipeList.Count; i++)
            {
                singleRecipes.Add(LevelController.instance.recipeList[i].GetComponent<SingleRecipe>());
            }
        }

        public void RecipeHandlerFunction(SingleRecipe singleRecipe,int value,string type)
        {
            singleRecipe.value -= value;
            singleRecipe.countText.text = singleRecipe.value <=0 ? $"Done" : $"x {singleRecipe.value}";
            if (DidWin())
            {
                LevelManager.gameState = GameState.Finish;
                CompletePanelController.instance.Activator();
                CompletePanelController.instance.SetFinalScoreText(value*5);
            }
        }

        private bool DidWin()
        {
            var valueList = singleRecipes.Select(recipe => recipe.value).ToList();
            // böyleydi eskiden
            //foreach (var recipe in singleRecipes)
            //{
            //    valueList.Add(recipe.value);
            //}
            valueList.Sort();
            return valueList[^1]<=0;
        }
    }
}