using System.Collections;
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


        [SerializeField] private List<Vector3> objectsWillBeDestroyed;
        [SerializeField] private List<Transform> stackedList;

        [SerializeField] private Transform targetPosition;
        [SerializeField] private Transform platePos;
        [SerializeField] private Transform tempParent;

        [SerializeField] private InputController inputController;
        public int StackedListCount => stackedList.Count;

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
                    //else if (interactable.type == InteractableTypes.Plate)
                    //{
                    //    //PlateAction(other.transform);
                    //}
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

                        stackedList.Add(objTransform);
                        var indexOfObj = stackedList.IndexOf(objTransform);
                        stackedList[indexOfObj].transform.parent = parent;
                        stackedList[indexOfObj].transform.position = new Vector3(parent.position.x,
                            parent.position.y + .2f,
                            parent.position.z);
                    }
                }
            }

            else
            {
                objTransform.GetComponent<BoxCollider>().enabled = false;
                stackedList.Add(objTransform);
                var indexOfObj = stackedList.IndexOf(objTransform);
                stackedList[indexOfObj].transform.parent = parent;
                stackedList[indexOfObj].transform.position = targetPosition.position;
            }
        }


        //platelerin üstünde taþýdýðý istek listesi script tarafýndan bilinmek zorunda,
        //toplanmýs olan objeler el tuþtan çekildiðinde, kendi türleriyle ayný türe sahip tabaða gideceðini bilmeliw
        //teker teker gider puff olur ve son obje oluþur
        //tabak listeden çýkar
        private void PlateAction(string type)
        {
            if (stackedList.Count <= 2) return;

            var plateTransform = GameObject.FindGameObjectWithTag(type).transform;
            foreach (var t in stackedList)
            {
                t.DOMove(plateTransform.position,.5f);
                t.parent = plateTransform;
            }
            RecipeController.instance.BilmemNe(plateTransform.GetChild(0).GetComponent<SingleRecipe>(),stackedList.Count,type);
            //þu aþaðýyý da düzenle
            //plateTransform.GetChild(0).GetComponent<SingleRecipe>().HandleRecipe(
            //    plateTransform.GetChild(0).GetComponent<SingleRecipe>().type,
            //    plateTransform.GetChild(0).GetComponent<SingleRecipe>().value,
            //    plateTransform.GetChild(0).GetComponent<SingleRecipe>().countText);

            DuringGamePanelController.instance.MoveCountDecrease();
            stackedList.Clear();

            FillerBoardManager.instance.TakeTransformInfos(objectsWillBeDestroyed);
            objectsWillBeDestroyed.Clear();
 

        }

        void Update()
        {
            if (!inputController.FingerHold)
            {
                GetComponent<BoxCollider>().enabled = false;
                if (!IsEnough())
                {
                    CancelMove();
                    if (transform.parent.GetChild(1).GetChild(1).childCount==0)
                    {
                        objectsWillBeDestroyed.Clear();
                        stackedList.Clear();
                    }
                }
                else
                {
                    if (stackedList[0].GetComponent<Interactable>().type ==InteractableTypes.Pancake)
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
                GetComponent<BoxCollider>().enabled = true;
            }
        }

        bool IsEnough()
        {
            if (stackedList.Count>2)
            {
                return true;
            }

            return false;
        }

        void CancelMove()
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