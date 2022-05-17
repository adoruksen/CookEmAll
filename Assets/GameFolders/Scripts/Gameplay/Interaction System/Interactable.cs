using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Interactable : MonoBehaviour
{
    public InteractableTypes type;
    public Vector3 firstPos;
    public bool isStacked = false;
    public Transform targetTransform;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(.2f);

        if (type is InteractableTypes.Pancake or InteractableTypes.Banana)
        {
            transform.DOPunchScale(new Vector3(.05f, .05f, .05f), .5f);
        }
    }


    void Update()
    {
        if (!isStacked) return;
        transform.position = Vector3.Lerp(transform.position, new Vector3(targetTransform.position.x, targetTransform.position.y + 0.133f, targetTransform.position.z), 0.75f);
        transform.rotation = targetTransform.rotation;
    }

}
