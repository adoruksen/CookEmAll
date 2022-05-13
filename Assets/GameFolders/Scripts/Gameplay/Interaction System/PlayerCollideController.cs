using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerCollideController : MonoBehaviour
{
    [SerializeField] private Transform pancakeParent;
    [SerializeField] private Transform bananaParent;
    void OnTriggerEnter(Collider other)
    {
        Interactable interactable = other.GetComponent<Interactable>();
        if (interactable != null)
        {
            if (interactable.type == InteractableTypes.Pancake)
            {
                if (bananaParent
                        .childCount > 0)
                {
                    return;
                }
                other.GetComponent<BoxCollider>().enabled = false;

                Debug.Log("pancake");
                other.transform.parent = pancakeParent;
                other.transform.localPosition= new Vector3(0,0.1f*pancakeParent.childCount,0);
            }
            else if (interactable.type == InteractableTypes.Banana)
            {
                if (pancakeParent.childCount > 0)
                {
                    return;
                }
                Debug.Log("banana");
                other.GetComponent<BoxCollider>().enabled = false;

                other.transform.parent = bananaParent;
                other.transform.localPosition = new Vector3(0, 0.2f * bananaParent.childCount, 0);


            }
            //else if (interactable.type == InteractableTypes.Plate)
            //{
            //   Debug.Log("plate");
            //   if (bananaParent.childCount>2||pancakeParent.childCount>2)
            //   {
            //       for (int i = 0; i < bananaParent.childCount; i++)
            //       {
            //           bananaParent.GetChild(i).transform.position = other.transform.position;
            //           bananaParent.GetChild(i).parent = other.transform;
            //           Debug.Log("muzlar býrakýldý");

            //       }
            //   }
            //}
        }
    }

}
