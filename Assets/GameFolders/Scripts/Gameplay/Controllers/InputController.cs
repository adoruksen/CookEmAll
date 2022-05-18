using UnityEngine;

namespace Assets.GameFolders.Scripts.Gameplay.Controllers
{
    public class InputController : MonoBehaviour
    {
        public bool FingerHold => Input.GetMouseButton(0);
        public bool FingerTap => Input.GetMouseButtonDown(0);
        public bool FingerUp => Input.GetMouseButtonUp(0);
    }

    //mouse'tan el �ekildi�inde stackler ilk yerlerine d�nmeli eger count 2 den k�c�kse
}
