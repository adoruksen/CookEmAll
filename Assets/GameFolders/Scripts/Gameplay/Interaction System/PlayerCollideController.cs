using System.Collections.Generic;
using UnityEngine;


//objectdestroyed hep alýyo, onu da typelara böl

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
    [SerializeField] private Transform targetPosition;

    [SerializeField] private List<Vector3> objectsWillBeDestroyed;
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
                    interactable.firstPos = other.transform.position;
                    objectsWillBeDestroyed.Add(interactable.firstPos);

                    StackedListController(other.transform,pancakeParent);

                    #region commented

                    //LineRendererController.instance.ColliderListController(other.transform);
                    //LineRendererController.instance.SetUpLine();

                    #endregion

                }
                else if (interactable.type == InteractableTypes.Banana)
                {
                    interactable.firstPos = other.transform.position;
                    objectsWillBeDestroyed.Add(interactable.firstPos);
                    StackedListController(other.transform,bananaParent);

                    #region commented

                    //LineRendererController.instance.ColliderListController(other.transform);
                    //LineRendererController.instance.SetUpLine();

                    #endregion
                }
                else if (interactable.type == InteractableTypes.Plate)
                {
                    Debug.Log("plate");
                    FillerBoardManager.instance.TakeTransformInfos(objectsWillBeDestroyed);
                    PlateAction(other.transform);
                }
            }
        }
    }


    private void StackedListController(Transform objTransform,Transform parent)
    {
        if (stackedList.Count > 0)
        {
            if (objTransform.GetComponent<Interactable>().type != stackedList[0].GetComponent<Interactable>().type)
                Debug.Log("ayný türde degil collider controller");
            else
                stackedList.Add(objTransform);
            int indexOfObj = stackedList.IndexOf(objTransform);
            stackedList[indexOfObj].GetComponent<BoxCollider>().enabled = false;
            stackedList[indexOfObj].transform.parent = parent;
            stackedList[indexOfObj].transform.position = new Vector3(stackedList[indexOfObj-1].transform.position.x, stackedList[indexOfObj - 1].transform.position.y + .1f, stackedList[indexOfObj - 1].transform.position.z);
        }

        else
        {
            stackedList.Add(objTransform);
            int indexOfObj = stackedList.IndexOf(objTransform);
            stackedList[indexOfObj].GetComponent<BoxCollider>().enabled = false;
            stackedList[indexOfObj].transform.parent = parent;
            stackedList[indexOfObj].transform.position = targetPosition.position;
        }
    }

    private void PlateAction(Transform platePosTransform)
    {
        foreach (var obj in stackedList)
        {
            obj.GetComponent<Interactable>().isStacked = false;
        }
        objectsWillBeDestroyed.Clear();
        if (stackedList.Count <= 2) return;
        foreach (var t in stackedList)
        {
            t.position = platePosTransform.position;
            t.parent = platePosTransform;
        }
        platePosTransform.GetChild(0).GetComponent<SingleRecipe>().HandleRecipe(
            platePosTransform.GetChild(0).GetComponent<SingleRecipe>().type,
            platePosTransform.GetChild(0).GetComponent<SingleRecipe>().value, platePosTransform.GetChild(0).GetComponent<SingleRecipe>().countText);

        DuringGamePanelController.instance.MoveCountDecrease();
        stackedList.Clear();
    }

}