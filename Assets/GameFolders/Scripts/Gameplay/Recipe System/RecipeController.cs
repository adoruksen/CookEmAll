using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RecipeController : MonoBehaviour
{
    public static RecipeController instance;
    private int finalVal;

    private void Awake()
    {
        instance = this;
    }


    [SerializeField] private TMP_Text textHolder;

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