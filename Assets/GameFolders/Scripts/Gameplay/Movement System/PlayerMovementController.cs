using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private Camera cam;
    private Collider planeCollider;
    private RaycastHit hit;
    private Ray ray;


    private Vector3 startPos;
    private Vector3 endPos;
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
            if (Physics.Raycast(ray, out hit))
                if (hit.collider == planeCollider)
                    transform.position = hit.point;
        }

        if (inputController.FingerTap)
        {
        }
    }
}