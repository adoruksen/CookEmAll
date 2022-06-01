using UnityEngine;
using DG.Tweening;
using CookEmAll.Managers;

namespace CookEmAll.Gameplay.Interaction_System
{
    public class Interactable : MonoBehaviour
    {
        public InteractableTypes type;
        [System.NonSerialized]public  Vector3 firstPos;
        public bool isStacked = false;
        public bool isPlate = false;
        public Transform targetTransform;

        void Update()
        {
            if (LevelManager.gameState is GameState.Normal or GameState.Finish)
            {
                if (isStacked)
                {
                    if (targetTransform != null)
                    {
                        transform.SetPositionAndRotation(Vector3.Lerp(transform.position, new Vector3(targetTransform.position.x, targetTransform.position.y + 0.08f, targetTransform.position.z), 10f * Time.deltaTime), targetTransform.rotation);
                    }
                }
                if (isPlate)
                {
                    if (targetTransform != null)
                    {
                        transform.DOJump(new Vector3(targetTransform.position.x, targetTransform.position.y + 0.08f, targetTransform.position.z), .01f, 1, .25f);
                        transform.rotation = targetTransform.rotation;
                    }
                    //transform.position = Vector3.Lerp(transform.position, new Vector3(targetTransform.position.x, targetTransform.position.y + 0.08f, targetTransform.position.z), 15f * Time.deltaTime);
                }
            }
            
        }
    }
}
