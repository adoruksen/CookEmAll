using CookEmAll.Gameplay.Controllers;
using CookEmAll.Managers;
using UnityEngine;

namespace CookEmAll.Gameplay.Movement_System
{
    public class PlayerMovementController : MonoBehaviour
    {
        private Camera cam;
        private Collider planeCollider;
        private RaycastHit hit;
        private Ray ray;


        [SerializeField] private InputController inputController;

        private void Awake()
        {
            inputController = new InputController();
            cam = GameObject.Find("Main Camera").GetComponent<Camera>();
            planeCollider = GameObject.Find("FreeRoamArea").GetComponent<Collider>();
        }
        private void Start()
        {
        }

        private void FixedUpdate()
        {
            if (LevelManager.gameState != GameState.Normal) return;
            if (inputController.FingerHold)
            {
                ray = cam.ScreenPointToRay(Input.mousePosition);
                if (!Physics.Raycast(ray, out hit)) return;
                if (hit.collider == planeCollider)
                    transform.position = hit.point;
            }
        }
    }
}