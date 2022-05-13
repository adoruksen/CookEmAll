using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public bool FingerHold => Input.GetMouseButton(0);
    public bool FingerPulled => Input.GetMouseButtonUp(1);
}
