using UnityEngine;

namespace Assets.GameFolders.Scripts.Gameplay.Controllers
{
    public class InputController : MonoBehaviour
    {
        public bool FingerHold => Input.GetMouseButton(0);
        public bool FingerTap => Input.GetMouseButtonDown(0);
        public bool FingerUp => Input.GetMouseButtonUp(0);
    }
}
