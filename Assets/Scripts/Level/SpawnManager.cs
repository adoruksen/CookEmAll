using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    static GameObject ovenParts;
    static GameObject banana;
    static GameObject pancake;

    static GameObject plate;

    static float firstDash;


    public static void Spawn(GridSpecs gridSpecs, int curPart , int lastPart)
    {
        ovenParts = new GameObject("OvenParts" + curPart);
        banana = new GameObject("Bananas" + curPart);
        pancake = new GameObject("Pancakes" + curPart);
        plate = new GameObject("Plate" + curPart);
       
        if (curPart != 1)
        {
            firstDash = FirstDashPosition(gridSpecs);
        }
        else
        {
            firstDash = 0;
        }

        for (int row = 0; row < gridSpecs.boardSize.x; row++)
        {
            for (int column = 0; column < gridSpecs.boardSize.y; column++)
            {
                Vector3 pos = new Vector3((row - firstDash ), 0, (gridSpecs.boardSize.y - column) );
                Instantiator("OvenParts", pos, ovenParts.transform, column,gridSpecs);
            }
        }

        for (int row = 0; row < gridSpecs.boardSize.x; row++)
        {
            for (int column = 0; column < gridSpecs.boardSize.y; column++)
            {
                if (gridSpecs.objType[row,column] == InteractableTypes.Banana)
                {
                    Vector3 pos = new Vector3(row - firstDash , .5f, (gridSpecs.boardSize.y - column));
                    Instantiator("Banana", pos, banana.transform,column,gridSpecs);
                }
                else if (gridSpecs.objType[row, column] == InteractableTypes.Pancake)
                {
                    Vector3 pos = new Vector3(row - firstDash , .5f, (gridSpecs.boardSize.y - column));
                    Instantiator("Pancake", pos, pancake.transform,column,gridSpecs);
                }
                else if (gridSpecs.objType[row, column] == InteractableTypes.Plate)
                {
                    Vector3 pos = new Vector3(row - firstDash , .5f, (gridSpecs.boardSize.y - column));
                    Instantiator("Plate", pos, plate.transform, column, gridSpecs);
                }
            }
        }
    }


    static float FirstDashPosition(GridSpecs gridSpecs)
    {
        for (int i = 0; i < gridSpecs.boardSize.x; i++)
        {
            if (gridSpecs.objType[i, gridSpecs.boardSize.y - 1] == InteractableTypes.Banana)
                return i;
        }
        return -1;

    }
    static void Instantiator(string objName,Vector3 insPos,Transform parent,int columnValue,GridSpecs gridSpecs)
    {
        GameObject obj = Instantiate(Resources.Load("Prefabs/" + objName,typeof(GameObject)) as GameObject,parent);
        obj.transform.position = insPos;
    }
}
