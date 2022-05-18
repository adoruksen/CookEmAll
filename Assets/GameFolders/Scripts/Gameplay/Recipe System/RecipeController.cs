using System.Collections.Generic;
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
            singleRecipe.countText.text = singleRecipe.value <=0 ? $"{type} Done" : $"{type} x {singleRecipe.value}";
            if (DidWin())
            {
                CompletePanelController.instance.transform.GetChild(0).gameObject.SetActive(true);
                Debug.Log("kazandýnýz");
            }
        }

        private bool DidWin()
        {
            var valueList = new List<int>();
            foreach (var recipe in singleRecipes)
            {
                valueList.Add(recipe.value);
            }
            valueList.Sort();
            return valueList[valueList.Count-1]<0;
        }
    }
}