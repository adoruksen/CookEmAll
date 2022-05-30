using System.Collections.Generic;
using System.Linq;
using CookEmAll.Managers;
using CookEmAll.UI;
using UnityEngine;

namespace CookEmAll.Gameplay.Recipe_System
{
    public class RecipeController : MonoBehaviour
    {
        public static RecipeController instance;
        public List<SingleRecipe> singleRecipes;
        [SerializeField] private ParticleSystem[] confettiParticle;

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
            switch (singleRecipe.value)
            {
                //singleRecipe.countText.text = singleRecipe.value <=0 ? $"Done" : $"x {singleRecipe.value}";
                case <= 0:
                    singleRecipe.countText.gameObject.SetActive(false);
                    singleRecipe.doneImg.SetActive(true);
                    break;
                default:
                    singleRecipe.countText.text = $"x{singleRecipe.value}";
                    break;
            }
            if (DidWin())
            {
                LevelManager.gameState = GameState.Finish;
                foreach (var item in confettiParticle)
                {
                    item.Play();
                }
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