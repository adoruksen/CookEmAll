using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCountController : MonoBehaviour
{
    public List<Transform> onPlateObjectsList;

    void Awake()
    {
        onPlateObjectsList.Add(transform);
    }

    private int ListCount()
    {
        return onPlateObjectsList.Count-1;
    }
}
