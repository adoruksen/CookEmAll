using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public bool FingerHold => Input.GetMouseButton(0);
    public bool FingerTap => Input.GetMouseButtonDown(0);
    public bool FingerUp => Input.GetMouseButtonUp(0);
}
