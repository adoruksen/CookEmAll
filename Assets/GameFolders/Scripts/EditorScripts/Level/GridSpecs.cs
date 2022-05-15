using System;
using UnityEngine;

public static class Consts
{
    public const int maxSize = 20; //gridlerin 20x20 den fazla olma �ans� yok
}

[Serializable]
public class GridSpecs
{
    public Vector2Int boardSize;


    public InteractableTypes[,]
        objType = new InteractableTypes[Consts.maxSize,
            Consts.maxSize]; //objelerin typelar�na g�re spawn edilmesini kolayla�t�racak board

    [NonSerialized] public Vector3 startPos;
}