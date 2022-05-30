using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

using DG.Tweening;
using MoreMountains.NiceVibrations;

using CookEmAll.Gameplay.Controllers;
using CookEmAll.Gameplay.Recipe_System;
using CookEmAll.Managers;
using CookEmAll.UI;



namespace CookEmAll.Gameplay.Interaction_System
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
        InputController inputController;
        CookerAnimatorController cookerAnimatorController;

        [Header("Components")] 
        [SerializeField] private BoxCollider playerCollider;


        private float maxDistance = 1.5f;

        private void Awake()
        {
            instance = this;
            inputController = new InputController();
            cookerAnimatorController = transform.parent.GetComponent<CookerAnimatorController>();
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
                            StackedListController(other.transform, targetPosition);

                            ObjectDestroyedListController(other.transform);
                            break;
                        case InteractableTypes.Egg:
                            StackedListController(other.transform, targetPosition);

                            ObjectDestroyedListController(other.transform);
                            break;
                        case InteractableTypes.Bacon:
                            StackedListController(other.transform, targetPosition);

                            ObjectDestroyedListController(other.transform);
                            break;
                        case InteractableTypes.Bagel:
                            StackedListController(other.transform, targetPosition);

                            ObjectDestroyedListController(other.transform);
                            break;
                        case InteractableTypes.Steak:
                            StackedListController(other.transform, targetPosition);

                            ObjectDestroyedListController(other.transform);
                            break;
                        case InteractableTypes.OvenParts:
                            cookerAnimatorController.MaterialColorChange(other.transform.GetChild(0).GetComponent<Animator>());
                            break;
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

        /// <summary>
        /// function that keeping the position data of gone objects, adding them to objectDestroyedList to reach out from fillerboardmanager
        /// </summary>
        private void ObjectDestroyedListController(Transform objDestroyed)
        {
            if (objectsWillBeDestroyed.Count > 0)
            {
                if (objDestroyed.GetComponent<Interactable>().type == stackedList[0].GetComponent<Interactable>().type)
                {
                    if (objectsWillBeDestroyed.Count < stackedList.Count)
                    {
                        objDestroyed.GetComponent<Interactable>().firstPos = objDestroyed.transform.position;
                        objectsWillBeDestroyed.Add(objDestroyed.GetComponent<Interactable>().firstPos);
                    }
                }
            }

            else
            {
                objDestroyed.GetComponent<Interactable>().firstPos = objDestroyed.transform.position;
                if (objectsWillBeDestroyed.Count < stackedList.Count)
                    objectsWillBeDestroyed.Add(objDestroyed.GetComponent<Interactable>().firstPos);
            }
        }


        /// <summary>
        /// function that controls objects are the same type or not. if it is, adding stackedList
        /// </summary>
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
                        MMVibrationManager.Haptic(HapticTypes.LightImpact);
                        objTransform.GetComponent<BoxCollider>().enabled = false;
                        objTransform.transform.parent = parent;
                        objTransform.GetComponent<Interactable>().targetTransform = stackedList[^1];
                        stackedList.Add(objTransform);
                        objTransform.DOPunchScale(new Vector3(.5f, .5f, .5f), .75f,1,1f);
                        objTransform.GetComponent<Interactable>().isStacked = true;
                        objTransform.GetChild(0).gameObject.SetActive(true);
                    }
                    else
                    {
                        MMVibrationManager.Haptic(HapticTypes.HeavyImpact);
                        objTransform.DOPunchScale(new Vector3(.1f,.1f,.1f), 1f);
                    }
                }
                else
                {
                    MMVibrationManager.Haptic(HapticTypes.HeavyImpact); 
                    objTransform.DOPunchScale(new Vector3(.1f, .1f, .1f), 1f);
                }
            }

            else
            {
                MMVibrationManager.Haptic(HapticTypes.LightImpact);
                objTransform.GetComponent<BoxCollider>().enabled = false;
                objTransform.transform.parent = parent;
                objTransform.GetComponent<Interactable>().targetTransform = targetPosition;
                stackedList.Add(objTransform);
                objTransform.DOPunchScale(new Vector3(.5f, .5f, .5f), .75f,1,1f);
                objTransform.GetComponent<Interactable>().isStacked = true;
                objTransform.GetChild(0).gameObject.SetActive(true);
            }
        }


        /// <summary>
        /// function that finds same type plate with stackedList objects. Working after we have at least 3 stacked object and mousebuttonup
        /// </summary>
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
            for (var i = 0; i < stackedList.Count; i++)
            {
                stackedList[i].GetComponent<Interactable>().targetTransform = i == 0 ? plateTransform.GetComponent<PlateCountController>().onPlateObjectsList[^1] : stackedList[i - 1];
                stackedList[i].rotation = plateTransform.rotation;
                stackedList[i].parent = plateTransform;
                plateTransform.GetComponent<PlateCountController>().AddToList(stackedList[i]);/*onPlateObjectsList.Add(stackedList[i])*/;
            }

            ParticleSystemController(stackedList.Count);
            RecipeController.instance.RecipeHandlerFunction(plateTransform.GetChild(1).GetComponent<SingleRecipe>(), stackedList.Count, type);

            DuringGamePanelController.instance.MoveCountDecrease();
            stackedList.Clear();

            FillerBoardManager.instance.TakeTransformInfos(objectsWillBeDestroyed);
            CompletePanelController.instance.plateMoveFinished = true;
            objectsWillBeDestroyed.Clear();

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
                stackedList[i].GetChild(0).gameObject.SetActive(false);
                stackedList[i].DOMove(objectsWillBeDestroyed[i], .2f);
                stackedList[i].DORotate(new Vector3(-90,0,0), .1f);
                stackedList[i].SetParent(tempParent);
                stackedList[i].GetComponent<BoxCollider>().enabled = true;
            }
        }


        private void ParticleSystemController(int value)
        {
            if (value == 5)
            {
                PlayerParticleController.instance.PlayParticle(0);
            }
            if (value == 6)
            {
                PlayerParticleController.instance.PlayParticle(1);
            }
            if (value == 7)
            {
                PlayerParticleController.instance.PlayParticle(2);
            }
            if (value >= 8)
            {
                PlayerParticleController.instance.PlayParticle(3);
            }
        }

       
    }
}