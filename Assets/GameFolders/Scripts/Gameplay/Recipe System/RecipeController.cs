using Assets.GameFolders.Scripts.Gameplay.Interaction_System;
using TMPro;
using UnityEngine;

namespace Assets.GameFolders.Scripts.Gameplay.Recipe_System
{
    public class RecipeController : MonoBehaviour
    {
        public static RecipeController instance;
        private int finalVal;

        private void Awake()
        {
            instance = this;
        }

        public void RecipeControllerFunction(InteractableTypes type, int value, TMP_Text textHolder)
        {
            if (type == InteractableTypes.Banana)
            {
                finalVal = value - PlayerCollideController.instance.StackedListCount;
                value = finalVal;
                textHolder.text = value <= 0 ? $"Done" : $"Banana x {value}";
            }

            if (type == InteractableTypes.Pancake)
            {
                finalVal = value - PlayerCollideController.instance.StackedListCount;
                value = finalVal;
                textHolder.text = value <= 0 ? $"Done" : $"Pancake x {value}";
            }
        }
    }
}