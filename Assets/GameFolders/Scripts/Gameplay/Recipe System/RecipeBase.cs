﻿using TMPro;
using UnityEngine;

namespace Assets.GameFolders.Scripts.Gameplay.Recipe_System
{
    public abstract class RecipeBase : MonoBehaviour
    {
        public virtual void TextSetter(InteractableTypes type, int value, TMP_Text textHolder, GameObject recipe)
        {
            textHolder.text = $"{type} x {value}";
        }

        //public virtual void HandleRecipe(InteractableTypes type,int value,TMP_Text textHolder)
        //{
        //    RecipeController.instance.RecipeControllerFunction(type,value,textHolder);
        //}
    }
}
