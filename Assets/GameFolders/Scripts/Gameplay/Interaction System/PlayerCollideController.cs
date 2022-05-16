using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlayerCollideController : MonoBehaviour
{
    public static PlayerCollideController instance;

    void Awake()
    {
        instance = this;
    }

    [SerializeField] private Transform bananaParent;
    [SerializeField] private Transform pancakeParent;
    [SerializeField] private List<Transform> stackedList;
    public int StackedListCount => stackedList.Count;

    private void OnTriggerEnter(Collider other)
    {
        if (LevelManager.gameState==GameState.Normal)
        {
            var interactable = other.GetComponent<Interactable>();
            if (interactable != null)
            {
                if (interactable.type == InteractableTypes.Pancake)
                {
                    StackedListController(other.transform, pancakeParent);
                    LineRendererController.instance.ColliderListController(other.transform);
                    LineRendererController.instance.SetUpLine();
                }
                else if (interactable.type == InteractableTypes.Banana)
                {
                    StackedListController(other.transform, bananaParent);
                    LineRendererController.instance.ColliderListController(other.transform);
                    LineRendererController.instance.SetUpLine();
                }
                else if (interactable.type == InteractableTypes.Plate)
                {
                    Debug.Log("plate");
                    PlateAction(other.transform);
                }
            }
        }
    }


    private void StackedListController(Transform objTransform, Transform parent)
    {
        if (stackedList.Count > 0)
        {
            if (objTransform.GetComponent<Interactable>().type != stackedList[0].GetComponent<Interactable>().type)
                Debug.Log("ayný türde degil collider controller");
            else
                stackedList.Add(objTransform);
            objTransform.GetComponent<BoxCollider>().enabled = false;
            //objTransform.transform.parent = parent;
            //objTransform.transform.localPosition = new Vector3(0,
            //    parent.GetChild(0).localScale.y * parent.childCount, 0);
        }

        else
        {
            stackedList.Add(objTransform);
            objTransform.GetComponent<BoxCollider>().enabled = false;
            //objTransform.transform.parent = parent;
            //objTransform.transform.localPosition = new Vector3(0,
            //    parent.GetChild(0).localScale.y * parent.childCount, 0);
        }
    }


    private void PlateAction(Transform platePosTransform)
    {
        if (stackedList.Count <= 2) return;
        foreach (var t in stackedList)
        {
            t.position = platePosTransform.position;
            t.parent = platePosTransform;
        }

        stackedList.Clear();
        LineRendererController.instance.ClearLines();
        DuringGamePanelController.instance.MoveCountDecrease();
        RecipeController.instance.RecipeControllerFunction(3);

    }
}