using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleRecipe : RecipeBase
{
    public InteractableTypes type;
    public int value;

    [SerializeField] GameObject recipe;
    [SerializeField] TMPro.TMP_Text countText;

    private void Awake()
    {
        TextSetter( type,value, countText, recipe);
    }
}
