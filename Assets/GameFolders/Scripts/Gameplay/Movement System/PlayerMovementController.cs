using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private Camera cam;
    private Collider planeCollider;
    private RaycastHit hit;
    private Ray ray;
    private Vector3 offset;
    [SerializeField] private InputController inputController;


    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        planeCollider = GameObject.Find("FreeRoamArea").GetComponent<Collider>();
    }

    void FixedUpdate()
    {
        if (inputController.FingerHold)
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider == planeCollider)
                {
                    transform.position = hit.point;

                }
            }
        }
    }

}
