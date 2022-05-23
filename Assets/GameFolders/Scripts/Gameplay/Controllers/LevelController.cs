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

    public List<GameObject> objectsCanBeInstantiated;
    public Vector3 cameraPos;
    public List<GameObject> recipeList;
}
