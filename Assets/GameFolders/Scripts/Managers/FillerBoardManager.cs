using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace CookEmAll.Managers
{
    public class FillerBoardManager : MonoBehaviour
    {
        public static FillerBoardManager instance;

        [SerializeField] private List<Transform> objectFillList;

        [SerializeField] private Transform objectsParent;

        void Awake()
        {
            instance = this;
        }

        void Start()
        {
            InitializeObjects();
        }

        void InitializeObjects()
        {
            for (var i = 0; i < LevelController.instance.moveCounter*10; i++)
            {
                var randomValue = Random.Range(0, LevelController.instance.objectsCanBeInstantiated.Count/*LevelManager.instance.LevelNumber*//*levelRules.levelObjects.Length*/);
                var insObject = Instantiate(LevelController.instance.objectsCanBeInstantiated[randomValue], objectsParent);
                insObject.GetComponent<BoxCollider>().enabled = false;
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
                objectFillList[i].DOMove(pos, .4f);
                objectFillList[i].GetComponent<BoxCollider>().enabled = true;
            }
            objectFillList.RemoveRange(0,destroyedObjectsList.Count);
            destroyedObjectsList.Clear();
        }
    }
}
