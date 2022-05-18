using Assets.GameFolders.Scripts.Gameplay.Controllers;
using Assets.GameFolders.Scripts.Managers;
using UnityEngine;

namespace Assets.GameFolders.Scripts.Gameplay.Movement_System
{
    public class PlayerMovementController : MonoBehaviour
    {
        private Camera cam;
        private Collider planeCollider;
        private RaycastHit hit;
        private Ray ray;


        [SerializeField] private InputController inputController;


        private void Start()
        {
            cam = GameObject.Find("Main Camera").GetComponent<Camera>();
            planeCollider = GameObject.Find("FreeRoamArea").GetComponent<Collider>();
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