using UnityEngine;

namespace Assets.GameFolders.Scripts.Gameplay.Recipe_System
{
    public class SingleRecipe : RecipeBase
    {
        public InteractableTypes type;
        public int value;

        [SerializeField] GameObject recipe;
        public TMPro.TMP_Text countText;

        private void Awake()
        {
            TextSetter( type,value, countText, recipe);
        }
    }
}
