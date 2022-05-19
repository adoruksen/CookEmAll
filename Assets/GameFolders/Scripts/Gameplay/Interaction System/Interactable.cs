using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Assets.GameFolders.Scripts.Gameplay.Interaction_System
{
    public class Interactable : MonoBehaviour
    {
        public InteractableTypes type;
        [System.NonSerialized]public  Vector3 firstPos;
        public bool isStacked = false;
        public Transform targetTransform ;

        IEnumerator Start()
        {
            yield return new WaitForSeconds(.2f);

            if (type is InteractableTypes.Pancake or InteractableTypes.Egg)
            {
                transform.DOPunchScale(new Vector3(.05f, .05f, .05f), .5f);
            }
        }


        void Update()
        {
            if (!isStacked) return;
            transform.position = Vector3.Lerp(transform.position, new Vector3(targetTransform.position.x, targetTransform.position.y + 0.133f, targetTransform.position.z), 5f*Time.deltaTime);
        }

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
