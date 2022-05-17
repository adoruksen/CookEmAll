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


    //public void FillTheBoard()
    //{
    //    for (int i = 0; i < targetPosList.Count; i++)
    //    {
    //        var pos = targetPosList[i].position;
    //        pancakeFillList[i].gameObject.SetActive(true);
    //        pancakeFillList[i].DOMove(pos, .5f);
    //        pancakeFillList.RemoveAt(i); 
    //    }
    //}

    public void TakeTransformInfos(List<Transform> destroyedObjectsList)
    {
        for (int i = 0; i < destroyedObjectsList.Count; i++)
        {
            var pos = destroyedObjectsList[i].position;
            pancakeFillList[i].gameObject.SetActive(true);
            pancakeFillList[i].DOMove(pos, .5f);
            //pancakeFillList.RemoveAt(i);
        }
        pancakeFillList.RemoveRange(0,destroyedObjectsList.Count);
    }

    //public void FillTheBoard(List<Transform> destroyedObjectsList)
    //{
    //    for (int i = 0; i < destroyedObjectsList.Count; i++)
    //    {
    //        var pos = destroyedObjectsList[i].position;
    //        pancakeFillList[i].gameObject.SetActive(true);
    //        pancakeFillList[i].DOMove(pos, .5f);
    //        pancakeFillList.RemoveAt(i);
    //    }
    //}

}
