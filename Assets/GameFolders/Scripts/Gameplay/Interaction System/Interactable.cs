using UnityEngine;

namespace Assets.GameFolders.Scripts.Gameplay.Interaction_System
{
    public class Interactable : MonoBehaviour
    {
        public InteractableTypes type;
        [System.NonSerialized]public  Vector3 firstPos;
        //public bool isStacked = false;
        //public Transform targetTransform;

        //IEnumerator Start()
        //{
        //    yield return new WaitForSeconds(.2f);

        //    if (type is InteractableTypes.Pancake or InteractableTypes.Banana)
        //    {
        //        transform.DOPunchScale(new Vector3(.05f, .05f, .05f), .5f);
        //    }
        //}


        //void Update()
        //{
        //    if (!isStacked) return;
        //    transform.position = Vector3.Lerp(transform.position, new Vector3(targetTransform.position.x, targetTransform.position.y + 0.133f, targetTransform.position.z), 0.75f);
        //    transform.rotation = targetTransform.rotation;
        //}

    }
}
