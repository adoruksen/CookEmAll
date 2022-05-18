using System.Collections.Generic;
using Assets.GameFolders.Scripts.Gameplay.Controllers;
using Assets.GameFolders.Scripts.Gameplay.Recipe_System;
using Assets.GameFolders.Scripts.Managers;
using Assets.GameFolders.Scripts.UI;
using DG.Tweening;
using UnityEngine;

namespace Assets.GameFolders.Scripts.Gameplay.Interaction_System
{
    [RequireComponent(typeof(Collider))]
    public class PlayerCollideController : MonoBehaviour
    {
        public static PlayerCollideController instance;

        [Header("Lists")]
        [SerializeField] private List<Vector3> objectsWillBeDestroyed;
        [SerializeField] private List<Transform> stackedList;

        [Header("Transforms")]
        [SerializeField] private Transform targetPosition;
        [SerializeField] private Transform tempParent;

        [Header("Scripts")]
        [SerializeField] private InputController inputController;

        [Header("Components")] 
        [SerializeField] private BoxCollider playerCollider;

        private float maxDistance = 1.5f;

        private void Awake()
        {
            instance = this;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (LevelManager.gameState == GameState.Normal)
            {
                var interactable = other.GetComponent<Interactable>();
                if (interactable != null)
                {
                    if (interactable.type == InteractableTypes.Pancake)
                    {
                        ObjectDestroyedListController(other.transform);
                        StackedListController(other.transform, targetPosition);
                    }
                    else if (interactable.type == InteractableTypes.Banana)
                    {
                        ObjectDestroyedListController(other.transform);
                        StackedListController(other.transform, targetPosition);
                    }
                }
            }
        }

        void Update()
        {
            if (LevelManager.gameState == GameState.Normal)
            {
                if (!inputController.FingerHold)
                {
                    playerCollider.enabled = false;
                    if (!IsEnough())
                    {
                        CancelMove();
                        if (targetPosition.childCount == 0)
                        {
                            objectsWillBeDestroyed.Clear();
                            stackedList.Clear();
                        }
                    }
                    else
                    {
                        if (stackedList[0].GetComponent<Interactable>().type == InteractableTypes.Pancake)
                        {
                            PlateAction("PancakePlate");
                        }
                        else
                        {
                            PlateAction("BananaPlate");
                        }
                    }
                }
                else
                {
                    playerCollider.enabled = true;
                }
            }

        }

        private void ObjectDestroyedListController(Component objDestroyed)
        {
            if (objectsWillBeDestroyed.Count > 0)
            {
                if (objDestroyed.GetComponent<Interactable>().type == stackedList[0].GetComponent<Interactable>().type)
                {
                    objDestroyed.GetComponent<Interactable>().firstPos = objDestroyed.transform.position;
                    if (objectsWillBeDestroyed.Count <= stackedList.Count)
                        objectsWillBeDestroyed.Add(objDestroyed.GetComponent<Interactable>().firstPos);
                }
            
            }
            else
            {
                objDestroyed.GetComponent<Interactable>().firstPos = objDestroyed.transform.position;
                if (objectsWillBeDestroyed.Count <= stackedList.Count)
                    objectsWillBeDestroyed.Add(objDestroyed.GetComponent<Interactable>().firstPos);
            }
        }

        private void StackedListController(Transform objTransform, Transform parent)
        {
            if (stackedList.Count > 0)
            {
                if (objTransform.GetComponent<Interactable>().type == stackedList[0].GetComponent<Interactable>().type)
                {
                    var curDistance = Mathf.Abs(Vector3.Distance(objTransform.position,
                        stackedList[stackedList.Count - 1].GetComponent<Interactable>().firstPos));
                    if (curDistance < maxDistance)
                    {
                        objTransform.GetComponent<BoxCollider>().enabled = false;

                        //var indexOfObj = stackedList.IndexOf(objTransform);
                        /*stackedList[indexOfObj]*/objTransform.transform.parent = parent;
                        ///*stackedList[indexOfObj]*/objTransform.transform.DOLocalJump(new Vector3(parent.position.x, stackedList[0].position.y + (.3f*stackedList.Count), parent.position.z),1f,1,.5f);
                        objTransform.GetComponent<Interactable>().targetTransform = stackedList[stackedList.Count-1];
                        stackedList.Add(objTransform);
                        objTransform.GetComponent<Interactable>().isStacked = true;

                    }
                }
            }

            else
            {
                objTransform.GetComponent<BoxCollider>().enabled = false;
                //var indexOfObj = stackedList.IndexOf(objTransform);
                /*stackedList[indexOfObj]*/
                objTransform.transform.parent = parent;
                /*stackedList[indexOfObj]*/
                //objTransform.transform.DOLocalJump(targetPosition.position,1f,1,.5f);
                objTransform.GetComponent<Interactable>().targetTransform = targetPosition;
                stackedList.Add(objTransform);
                objTransform.GetComponent<Interactable>().isStacked = true;
            }
        }
        private void PlateAction(string type)
        {
            if (stackedList.Count <= 2) return;

            foreach (var stacked in stackedList)
            {
                stacked.GetComponent<Interactable>().isStacked = false;
            }
            var plateTransform = GameObject.FindGameObjectWithTag(type).transform;
            foreach (var t in stackedList)
            {
                t.DOMove(plateTransform.position,.5f);
                t.parent = plateTransform;
            }
            RecipeController.instance.RecipeHandlerFunction(plateTransform.GetChild(0).GetComponent<SingleRecipe>(),stackedList.Count,type);
           
            DuringGamePanelController.instance.MoveCountDecrease();
            stackedList.Clear();

            FillerBoardManager.instance.TakeTransformInfos(objectsWillBeDestroyed);
            objectsWillBeDestroyed.Clear();
 

        }


        private bool IsEnough()
        {
            return stackedList.Count>2;
        }

        private void CancelMove()
        {
            for (int i = 0; i < stackedList.Count; i++)
            {
                stackedList[i].DOMove(objectsWillBeDestroyed[i], .1f);
                stackedList[i].SetParent(tempParent );
                stackedList[i].GetComponent<BoxCollider>().enabled = true;
            }
        }
    }
}