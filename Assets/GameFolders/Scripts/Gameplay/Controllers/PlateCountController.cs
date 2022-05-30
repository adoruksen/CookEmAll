using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CookEmAll.Gameplay.Interaction_System;

public class PlateCountController : MonoBehaviour
{
    public List<Transform> onPlateObjectsList;

    void Start()
    {
        onPlateObjectsList.Add(transform);
    }

    //private int ListCount()
    //{
    //    return onPlateObjectsList.Count-1;
    //}

    public void AddToList(Transform stackedObject)
    {
        onPlateObjectsList.Add(stackedObject);
        StartCoroutine(ListIsPlateFalse());
    }

    IEnumerator ListIsPlateFalse()
    {
        yield return new WaitForSeconds(2f);
        foreach (var item in onPlateObjectsList)
        {
            if (item.TryGetComponent<Interactable>(out var interactable))
            {
                interactable.isPlate = false;
            }
        }
    }
}
