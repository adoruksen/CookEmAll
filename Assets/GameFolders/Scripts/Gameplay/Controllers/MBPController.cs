using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBPController : MonoBehaviour
{
    private Color mainColor = Color.black;
    private Renderer renderer = null;
    private MaterialPropertyBlock materialPropertyBlock = null;


    void Start()
    {
        renderer = GetComponent<Renderer>();
        materialPropertyBlock = new MaterialPropertyBlock();
    }
    void Update()
    {
        materialPropertyBlock.SetColor("_Color",mainColor);
        renderer.SetPropertyBlock(materialPropertyBlock);
    }
}
