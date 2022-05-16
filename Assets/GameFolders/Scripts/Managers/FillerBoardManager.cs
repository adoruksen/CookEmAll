using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillerBoardManager : MonoBehaviour
{
    public static FillerBoardManager instance;

    void Awake()
    {
        instance = this;
    }

    public void PosSetter(Transform transform, Vector3 endPos)
    {
        transform.position = endPos;
    }
}
