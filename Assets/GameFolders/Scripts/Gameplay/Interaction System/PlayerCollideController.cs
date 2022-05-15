using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlayerCollideController : MonoBehaviour
{
    [SerializeField] private Transform bananaParent;
    [SerializeField] private Transform pancakeParent;
    [SerializeField] private List<Transform> stackedList;

    private void OnTriggerEnter(Collider other)
    {
        var interactable = other.GetComponent<Interactable>();
        if (interactable != null)
        {
            if (interactable.type == InteractableTypes.Pancake)
            {
                StackedListController(other.transform, pancakeParent);
                LineRendererController.instance.ColliderListController(other.transform);
            }
            else if (interactable.type == InteractableTypes.Banana)
            {
                StackedListController(other.transform, bananaParent);
                LineRendererController.instance.ColliderListController(other.transform);
            }
            else if (interactable.type == InteractableTypes.Plate)
            {
                Debug.Log("plate");
                PlateAction(other.transform);
            }
        }
    }


    private void StackedListController(Transform objTransform, Transform parent)
    {
        if (stackedList.Count > 0)
        {
            if (objTransform.GetComponent<Interactable>().type != stackedList[0].GetComponent<Interactable>().type)
            {
                Debug.Log("ayný türde degil collider controller");
            }
            else
            {
                stackedList.Add(objTransform);
                objTransform.GetComponent<BoxCollider>().enabled = false;
                objTransform.transform.parent = parent;
                objTransform.transform.localPosition = new Vector3(0,
                    parent.GetChild(0).localScale.y * parent.childCount, 0);
            }
        }

        else
        {
            stackedList.Add(objTransform);
            objTransform.GetComponent<BoxCollider>().enabled = false;
            objTransform.transform.parent = parent;
            objTransform.transform.localPosition = new Vector3(0,
                parent.GetChild(0).localScale.y * parent.childCount, 0);
        }
    }


    void PlateAction(Transform platePosTransform)
    {
        if (stackedList.Count > 2)
        {
            for (int i = 0; i < stackedList.Count; i++)
            {
                stackedList[i].position = platePosTransform.position;
                stackedList[i].parent = platePosTransform;
            }
            stackedList.Clear();
        }
        
    }
}