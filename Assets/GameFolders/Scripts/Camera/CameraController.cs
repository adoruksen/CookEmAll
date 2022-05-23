using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    void Start()
    {
        transform.position = LevelController.instance.cameraPos;
    }

}
