using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Assets.GameFolders.Scripts.Managers
{
    public class FillerBoardManager : MonoBehaviour
    {
        public static FillerBoardManager instance;

        [SerializeField] private List<Transform> objectFillList;

        [SerializeField] private LevelRules levelRules;

        [SerializeField] private Transform objectsParent;

        void Awake()
        {
            instance = this;
            InitializeObjects();
        }

        void InitializeObjects()
        {
            for (int i = 0; i < 150; i++)
            {
                var randomValue = Random.Range(0, levelRules.levelObjects.Length);
                GameObject insObject = Instantiate(levelRules.levelObjects[randomValue], objectsParent);
                insObject.GetComponent<BoxCollider>().isTrigger = false;
                insObject.SetActive(false);
                objectFillList.Add(insObject.transform);
            }
        }
        public void TakeTransformInfos(List<Vector3> destroyedObjectsList)
        {
            for (var i = 0; i < destroyedObjectsList.Count; i++)
            {
                var pos = destroyedObjectsList[i];
                objectFillList[i].gameObject.SetActive(true);
                objectFillList[i].DOMove(pos, .5f);
                objectFillList[i].GetComponent<BoxCollider>().isTrigger = true;
            }
            objectFillList.RemoveRange(0,destroyedObjectsList.Count);
        }

    }
}
