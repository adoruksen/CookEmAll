using UnityEngine;

namespace CookEmAll.Gameplay.Controllers
{
    public class InputController
    {
        public bool FingerHold => Input.GetMouseButton(0);
        public bool FingerTap => Input.GetMouseButtonDown(0);
        public bool FingerUp => Input.GetMouseButtonUp(0);

    }
}
