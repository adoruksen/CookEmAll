using TMPro;
using UnityEngine;

namespace Assets.GameFolders.Scripts.Gameplay.Recipe_System
{
    public abstract class RecipeBase : MonoBehaviour
    {
        public virtual void TextSetter(int value, TMP_Text textHolder, GameObject recipe, GameObject doneImg)
        {
            textHolder.text = $"x{value}";
        }

        //public virtual void HandleRecipe(InteractableTypes type,int value,TMP_Text textHolder)
        //{
        //    RecipeController.instance.RecipeControllerFunction(type,value,textHolder);
        //}
    }
}
