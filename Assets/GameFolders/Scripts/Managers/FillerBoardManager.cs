using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FillerBoardManager : MonoBehaviour
{
    public static FillerBoardManager instance;

    [SerializeField] private List<Transform> pancakeFillList;

    [SerializeField] private List<Transform> targetPosList;

    void Awake()
    {
        instance = this;
    }
    
    public void TakeTransformInfos(List<Vector3> destroyedObjectsList)
    {
        for (int i = 0; i < destroyedObjectsList.Count; i++)
        {
            var pos = destroyedObjectsList[i];
            pancakeFillList[i].gameObject.SetActive(true);
            pancakeFillList[i].DOMove(pos, .5f);
        }
        pancakeFillList.RemoveRange(0,destroyedObjectsList.Count);
    }

}
