using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CookEmAll.Gameplay.Interaction_System;
using CookEmAll.UI;

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
    }
    public void ListPlateFalse()
    {
        StartCoroutine(ListIsPlateFalse());
    }
    IEnumerator ListIsPlateFalse()
    {
        yield return new WaitForSeconds(1f);
        foreach (var item in onPlateObjectsList)
        {
            if (item.TryGetComponent<Interactable>(out var interactable))
            {
                if (Mathf.Abs(item.transform.position.y - interactable.targetTransform.position.y) > 0.08f)
                    interactable.isPlate = false;
            }
        }
    }
}
