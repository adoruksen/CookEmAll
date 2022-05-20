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
            if (!isStacked) return;
            transform.position = Vector3.Lerp(transform.position, new Vector3(targetTransform.position.x, targetTransform.position.y + 0.133f, targetTransform.position.z), 5f*Time.deltaTime);
            transform.rotation = targetTransform.rotation;

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
