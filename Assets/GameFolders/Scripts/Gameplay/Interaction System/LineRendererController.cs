using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineRendererController : MonoBehaviour
{
    public static LineRendererController instance;

    public List<Transform> colliderList;
    //ilk basta bir collidera basýlýyor olmalý, basýldýgýnda true olacak bir boolean kontrol edilecek.
    //collidera basýldýðý anda type ý bilinecek ve listeye eklenecek.
    //sonrasýnda line oluþacak ve mouseposition u takip edecek. line ýn max uzunlugu olacak
    //mouse position bir collidera denk geldiginde , typelar karsýlastýrýlacak,
    //typelar uyuþuyorsa line renderer ilk collider olarak son dokunulaný sececek ve islem yeniden baslayacak
    //collider sayýsý üçten fazlaysa tamamdýr kardes diyecek

    private LineRenderer lineRenderer;

    private void Awake()
    {
        instance = this;
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void ColliderListController(Transform objTransform)
    {
        if (colliderList.Count > 0)
        {
            if (objTransform.GetComponent<Interactable>().type != colliderList[0].GetComponent<Interactable>().type)
            {
                Debug.Log("bu iki obje ayný türden degil birleþemez");
            }
            else
            {
                lineRenderer.positionCount = colliderList.Count;
                objTransform.GetChild(0).gameObject.SetActive(true);
                colliderList.Add(objTransform);
            }
        }

        else
        {
            lineRenderer.positionCount = colliderList.Count;
            objTransform.GetChild(0).gameObject.SetActive(true);
            colliderList.Add(objTransform);
        }
    }

    public void SetUpLine()
    {
        lineRenderer.positionCount = colliderList.Count;
        for (var i = 0; i < colliderList.Count; i++)
        {
            lineRenderer.SetPosition(i,colliderList[i].position);
        }
    }

    public void ClearLines()
    {
        colliderList.Clear();
        lineRenderer.positionCount = 0;
    }
}