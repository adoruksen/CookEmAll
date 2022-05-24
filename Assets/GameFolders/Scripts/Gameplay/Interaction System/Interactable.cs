using System.Collections;
using UnityEngine;
using DG.Tweening;

namespace Assets.GameFolders.Scripts.Gameplay.Interaction_System
{
    public class Interactable : MonoBehaviour
    {
        public InteractableTypes type;
        [System.NonSerialized]public  Vector3 firstPos;
        public bool isStacked = false;
        public bool isPlate = false;
        public Transform targetTransform ;

        IEnumerator Start()
        {
            yield return new WaitForSeconds(1f);

            if (type is InteractableTypes.Pancake or InteractableTypes.Egg)
            {
                transform.DOPunchScale(new Vector3(.075f, .075f, .075f), .3f);
            }
        }


        void Update()
        {
            if (isStacked)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(targetTransform.position.x, targetTransform.position.y + 0.133f, targetTransform.position.z), 10f * Time.deltaTime);
                transform.rotation = targetTransform.rotation;
            }


            if (isPlate)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(targetTransform.position.x, targetTransform.position.y + 0.05f, targetTransform.position.z), 15f * Time.deltaTime);
                transform.rotation = targetTransform.rotation;
            }
            

        }

        //void OnTriggerExit(Collider other)
        //{
        //    Debug.Log("buna girdi" + other.name);
        //    if (type!= InteractableTypes.OvenParts)
        //    {
        //        var interactable = other.GetComponent<Interactable>();
        //        if (interactable != null)
        //        {
        //            if (interactable.type == InteractableTypes.OvenParts)
        //            {
        //                Debug.Log("carpisma old");
        //                MaterialColorChange(other.GetComponent<Renderer>());
        //            }
        //        }
        //    }
        //}


        

        //public void MoveElements(List<Transform> collected)
        //{
        //    for (var i = 1; i < collected.Count; i++)
        //    {
        //        var pos = collected[i].transform.position;
        //        pos.x = collected[i - 1].transform.position.x;
        //        collected[i].transform.position = Vector3.Lerp(collected[i].transform.position, pos, .25f * Time.deltaTime);
        //    }
        //}
    }
}
