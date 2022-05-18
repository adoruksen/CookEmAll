using System;
using Assets.GameFolders.Scripts.Gameplay.Interaction_System;
using TMPro;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.GameFolders.Scripts.Gameplay.Recipe_System
{
    public class RecipeController : MonoBehaviour
    {
        public static RecipeController instance;
        [SerializeField] private List<SingleRecipe> singleRecipes;
        private void Awake()
        {
            instance = this;
        }

        //public void RecipeControllerFunction(InteractableTypes type, int value, TMP_Text textHolder)
        //{
        //    if (type == InteractableTypes.Banana)
        //    {
        //        finalVal = value - PlayerCollideController.instance.StackedListCount;
        //        value = finalVal;
        //        textHolder.text = value <= 0 ? $"Done" : $"Banana x {value}";
        //    }

        //    if (type == InteractableTypes.Pancake)
        //    {
        //        finalVal = value - PlayerCollideController.instance.StackedListCount;
        //        value = finalVal;
        //        textHolder.text = value <= 0 ? $"Done" : $"Pancake x {value}";
        //    }
        //}

        public void BilmemNe(SingleRecipe singleRecipe,int value,string type)
        {
            singleRecipe.value -= value;
            singleRecipe.countText.text = singleRecipe.value <=0 ? $"{type} Done" : $"{type} x {singleRecipe.value}";
            if (DidWin())
            {
                Debug.Log("kazandýnýz");
            }
        }

        bool DidWin()
        {
            var valueList = new List<int>();
            for (var i = 0; i < singleRecipes.Count; i++)
            {
                valueList.Add(singleRecipes[i].value);
            }
            valueList.Sort();
            if (valueList[valueList.Count-1]<0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}