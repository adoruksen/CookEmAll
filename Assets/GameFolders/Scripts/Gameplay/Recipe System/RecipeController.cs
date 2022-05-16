using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RecipeController : MonoBehaviour
{
    public static RecipeController instance;

    public List<GameObject> recipeObjects;
    private int currentLevel = 0;

    void Awake()
    {
        instance = this;
    }


    [SerializeField] private TMP_Text textHolder;


    public void RecipeControllerFunction(int value)
    {
        //recipeObjects[0].GetComponent<SingleRecipe>().type
        //matematiksel iþlem yapýlacak sadece
        int finalVal = value - PlayerCollideController.instance.StackedListCount;
        if (finalVal <= 0)
        {
            textHolder.text = "okey";
        }
    }

    //public void Something()
    //{
    //    if (currentLevel < recipeObjects.Count)
    //    {
    //        recipeObjects[currentLevel].GetComponent<SingleRecipe>().HandleRecipe(recipeObjects[currentLevel].GetComponent<SingleRecipe>().type, recipeObjects[currentLevel].GetComponent<SingleRecipe>().value);
    //        currentLevel++;
    //    }
    //}
    
}
