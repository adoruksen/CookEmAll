using UnityEngine;
using Assets.GameFolders.Scripts.Gameplay.Controllers;
using DG.Tweening;

public class SpatulaController : MonoBehaviour
{
    [SerializeField] private Transform stackArea;
    [SerializeField] private InputController inputController;
    [SerializeField] Transform objectToFollow;
    [SerializeField] Vector3 offset;
    [SerializeField] Transform firstTransform;

    void Update()
    {
        if (inputController.FingerHold)
        {
            transform.position = Vector3.Lerp(transform.position, objectToFollow.position + offset, 10*Time.deltaTime);
        }
        if (inputController.FingerUp)
        {
            transform.DOMove( firstTransform.position,1f);/*Vector3.Lerp(transform.position, firstTransform.position, 10*Time.deltaTime);*/
        }
    }

}
