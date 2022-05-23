using System;
using System.Collections.Generic;
using System.Collections;
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
                    switch (interactable.type)
                    {
                        case InteractableTypes.Pancake:
                            ObjectDestroyedListController(other.transform);
                            StackedListController(other.transform, targetPosition);
                            break;
                        case InteractableTypes.Egg:
                            ObjectDestroyedListController(other.transform);
                            StackedListController(other.transform, targetPosition);
                            break;
                        case InteractableTypes.Bacon:
                            ObjectDestroyedListController(other.transform);
                            StackedListController(other.transform, targetPosition);
                            break;
                        case InteractableTypes.Bagel:
                            ObjectDestroyedListController(other.transform);
                            StackedListController(other.transform, targetPosition);
                            break;
                        case InteractableTypes.Steak:
                            ObjectDestroyedListController(other.transform);
                            StackedListController(other.transform, targetPosition);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
        }

        void Update()
        {
            if (LevelManager.gameState != GameState.Normal) return;
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
                    else if (stackedList[0].GetComponent<Interactable>().type == InteractableTypes.Egg)
                    {
                        PlateAction("EggPlate");
                    }
                    else if (stackedList[0].GetComponent<Interactable>().type == InteractableTypes.Bacon)
                    {
                        PlateAction("BaconPlate");
                    }
                    else if (stackedList[0].GetComponent<Interactable>().type == InteractableTypes.Bagel)
                    {
                        PlateAction("BagelPlate");
                    }
                    else if (stackedList[0].GetComponent<Interactable>().type == InteractableTypes.Steak)
                    {
                        PlateAction("SteakPlate");
                    }
                }
            }
            else
            {
                playerCollider.enabled = true;
            }
        }

        private void ObjectDestroyedListController(Transform objDestroyed)
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
                        stackedList[^1].GetComponent<Interactable>().firstPos));
                    if ((curDistance < maxDistance))
                    {
                        objTransform.GetComponent<BoxCollider>().enabled = false;
                        objTransform.transform.parent = parent;
                        objTransform.GetComponent<Interactable>().targetTransform = stackedList[^1];
                        stackedList.Add(objTransform);
                        objTransform.GetComponent<Interactable>().isStacked = true;
                        objTransform.GetChild(0).gameObject.SetActive(true);
                    }
                }
            }

            else
            {
                objTransform.GetComponent<BoxCollider>().enabled = false;
                objTransform.transform.parent = parent;
                objTransform.GetComponent<Interactable>().targetTransform = targetPosition;
                stackedList.Add(objTransform);
                objTransform.GetComponent<Interactable>().isStacked = true;
                objTransform.GetChild(0).gameObject.SetActive(true);

            }
        }
        private void PlateAction(string type)
        {
            if (stackedList.Count <= 2) return;

            DuringGamePanelController.instance.UpdateCoin(stackedList.Count*2);
            foreach (var stacked in stackedList)
            {
                stacked.GetComponent<Interactable>().isStacked = false;
                stacked.GetComponent<Interactable>().isPlate = true;
            }
            var plateTransform = GameObject.FindGameObjectWithTag(type).transform;
            for (int i = 0; i < stackedList.Count; i++)
            {
                stackedList[i].GetComponent<Interactable>().targetTransform = i==0 ? plateTransform : stackedList[i - 1];
                stackedList[i].rotation = plateTransform.rotation;
                stackedList[i].parent = plateTransform;
            }
            //foreach (var t in stackedList)
            //{
            //    t.GetComponent<Interactable>().targetTransform = plateTransform;
            //    //t.DOMove(plateTransform.position,.5f);
            //    t.rotation = plateTransform.rotation;
            //    t.parent = plateTransform;
            //}
            RecipeController.instance.RecipeHandlerFunction(plateTransform.GetChild(1).GetComponent<SingleRecipe>(),stackedList.Count,type);
           
            //DuringGamePanelController.instance.MoveCountDecrease();
            stackedList.Clear();

            FillerBoardManager.instance.TakeTransformInfos(objectsWillBeDestroyed);
            objectsWillBeDestroyed.Clear();
            CompletePanelController.instance.plateMoveFinished = true;
        }

        private bool IsEnough()
        {
            return stackedList.Count>2;
        }

        private void CancelMove()
        {
            for (var i = 0; i < stackedList.Count; i++)
            {
                stackedList[i].GetComponent<Interactable>().isStacked = false;
                stackedList[i].DOMove(objectsWillBeDestroyed[i], .2f);
                stackedList[i].DORotate(new Vector3(-90,0,0), .1f);
                stackedList[i].SetParent(tempParent);
                stackedList[i].GetComponent<BoxCollider>().enabled = true;
            }
        }
    }
}