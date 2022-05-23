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

        public void RecipeHandlerFunction(SingleRecipe singleRecipe,int value,string type)
        {
            singleRecipe.value -= value;
            singleRecipe.countText.text = singleRecipe.value <=0 ? $"Done" : $"x {singleRecipe.value}";
            if (DidWin())
            {
                CompletePanelController.instance.Activator();
                CompletePanelController.instance.SetFinalScoreText(GameManager.Coin*5);
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