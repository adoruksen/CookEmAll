using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private static GameObject ovenParts;
    private static GameObject banana;
    private static GameObject pancake;

    private static GameObject plate;

    private static float firstDash;


    public static void Spawn(GridSpecs gridSpecs, int curPart, int lastPart)
    {
        ovenParts = new GameObject("OvenParts" + curPart);
        banana = new GameObject("Eggs" + curPart);
        pancake = new GameObject("Pancakes" + curPart);
        plate = new GameObject("Plate" + curPart);

        if (curPart != 1)
            firstDash = FirstDashPosition(gridSpecs);
        else
            firstDash = 0;

        for (var row = 0; row < gridSpecs.boardSize.x; row++)
        for (var column = 0; column < gridSpecs.boardSize.y; column++)
        {
            var pos = new Vector3(row - firstDash, 0, gridSpecs.boardSize.y - column);
            Instantiator("OvenParts", pos, ovenParts.transform, column, gridSpecs);
        }

        for (var row = 0; row < gridSpecs.boardSize.x; row++)
        for (var column = 0; column < gridSpecs.boardSize.y; column++)
            if (gridSpecs.objType[row, column] == InteractableTypes.Egg)
            {
                var pos = new Vector3(row - firstDash, .65f, gridSpecs.boardSize.y - column);
                Instantiator("Egg", pos, banana.transform, column, gridSpecs);
            }
            else if (gridSpecs.objType[row, column] == InteractableTypes.Pancake)
            {
                var pos = new Vector3(row - firstDash, .65f, gridSpecs.boardSize.y - column);
                Instantiator("Pancake", pos, pancake.transform, column, gridSpecs);
            }
            else if (gridSpecs.objType[row, column] == InteractableTypes.Plate)
            {
                var pos = new Vector3(row - firstDash, .5f, gridSpecs.boardSize.y - column);
                Instantiator("Plate", pos, plate.transform, column, gridSpecs);
            }
    }


    private static float FirstDashPosition(GridSpecs gridSpecs)
    {
        for (var i = 0; i < gridSpecs.boardSize.x; i++)
            if (gridSpecs.objType[i, gridSpecs.boardSize.y - 1] == InteractableTypes.Egg)
                return i;
        return -1;
    }

    private static void Instantiator(string objName, Vector3 insPos, Transform parent, int columnValue,
        GridSpecs gridSpecs)
    {
        var obj = Instantiate(Resources.Load("Prefabs/" + objName, typeof(GameObject)) as GameObject, parent);
        obj.transform.position = insPos;
    }
}