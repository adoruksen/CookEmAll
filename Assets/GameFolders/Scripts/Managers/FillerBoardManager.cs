using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FillerBoardManager : MonoBehaviour
{
    public static FillerBoardManager instance;

    [SerializeField] private List<Transform> pancakeFillList;

    void Awake()
    {
        instance = this;
    }


    public void FillTheBoard(List<Transform> destroyedObjectsList)
    {
        for (int i = 0; i < destroyedObjectsList.Count; i++)
        {
            var pos = destroyedObjectsList[i].position;
            pancakeFillList[i].gameObject.SetActive(true);
            pancakeFillList[i].DOMove(pos, .5f);
            pancakeFillList.RemoveAt(i); 
        }
    }

}
