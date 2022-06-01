using UnityEngine;
using CookEmAll.Gameplay.Controllers;
using DG.Tweening;
using CookEmAll.Managers;

namespace CookEmAll.Gameplay.Movement_System
{
    public class SpatulaController : MonoBehaviour
    {
        [SerializeField] private Transform stackArea;
        InputController inputController;
        [SerializeField] Transform objectToFollow;
        [SerializeField] Vector3 offset;
        [SerializeField] Transform firstTransform;
        private void Awake()
        {
            inputController = new InputController();
        }

        void Update()
        {
            Debug.Log(LevelManager.gameState);
            if (LevelManager.gameState == GameState.Normal)
            {
                if (inputController.FingerHold)
                {
                    transform.position = Vector3.Lerp(transform.position, objectToFollow.position + offset, 10 * Time.deltaTime);
                }
                if (inputController.FingerUp)
                {
                    transform.position = Vector3.Lerp(transform.position,firstTransform.position, 5*Time.deltaTime);/*Vector3.Lerp(transform.position, firstTransform.position, 10*Time.deltaTime);*/
                }
            }

        }

    }
}

