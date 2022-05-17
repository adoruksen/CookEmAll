using System.Collections.Generic;
using UnityEngine;


//objectdestroyed hep alýyo, onu da typelara böl

[RequireComponent(typeof(Collider))]
public class PlayerCollideController : MonoBehaviour
{
    public static PlayerCollideController instance;

    [SerializeField] private Transform bananaParent;

    [SerializeField] private List<Vector3> objectsWillBeDestroyed;
    [SerializeField] private Transform pancakeParent;
    [SerializeField] private List<Transform> stackedList;
    [SerializeField] private Transform targetPosition;
    public int StackedListCount => stackedList.Count;

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
                    StackedListController(other.transform, pancakeParent);
                }
                else if (interactable.type == InteractableTypes.Banana)
                {
                    ObjectDestroyedListController(other.transform);
                    StackedListController(other.transform, bananaParent);
                }
                else if (interactable.type == InteractableTypes.Plate)
                {
                    FillerBoardManager.instance.TakeTransformInfos(objectsWillBeDestroyed);
                    PlateAction(other.transform);
                }
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
                stackedList.Add(objTransform);
                var indexOfObj = stackedList.IndexOf(objTransform);
                stackedList[indexOfObj].GetComponent<BoxCollider>().enabled = false;
                stackedList[indexOfObj].transform.parent = parent;
                stackedList[indexOfObj].transform.position = new Vector3(stackedList[indexOfObj - 1].transform.position.x,
                    stackedList[indexOfObj - 1].transform.position.y + .2f,
                    stackedList[indexOfObj - 1].transform.position.z);
            }
        }

        else
        {
            stackedList.Add(objTransform);
            var indexOfObj = stackedList.IndexOf(objTransform);
            stackedList[indexOfObj].GetComponent<BoxCollider>().enabled = false;
            stackedList[indexOfObj].transform.parent = parent;
            stackedList[indexOfObj].transform.position = targetPosition.position;
        }
    }

    private void PlateAction(Transform platePosTransform)
    {
        foreach (var obj in stackedList) obj.GetComponent<Interactable>().isStacked = false;
        objectsWillBeDestroyed.Clear();
        if (stackedList.Count <= 2) return;
        foreach (var t in stackedList)
        {
            t.position = platePosTransform.position;
            t.parent = platePosTransform;
        }

        platePosTransform.GetChild(0).GetComponent<SingleRecipe>().HandleRecipe(
            platePosTransform.GetChild(0).GetComponent<SingleRecipe>().type,
            platePosTransform.GetChild(0).GetComponent<SingleRecipe>().value,
            platePosTransform.GetChild(0).GetComponent<SingleRecipe>().countText);

        DuringGamePanelController.instance.MoveCountDecrease();
        stackedList.Clear();
    }
}