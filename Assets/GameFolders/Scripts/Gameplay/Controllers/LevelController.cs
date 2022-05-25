using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController instance;

    void Awake()
    {
        instance = this;
    }
    [Header("Level Contains:")]
    public bool egg;
    public bool pancake;
    public bool bagel;
    public bool bacon;
    public bool steak;

    public List<GameObject> objectsCanBeInstantiated;

    public List<GameObject> recipeList;

    [Header("Level Settings")]
    public Vector3 cameraPos;
    public int moveCounter;


}
