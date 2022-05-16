using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineRendererController : MonoBehaviour
{
    public static LineRendererController instance;

    public List<Transform> colliderList;
    //ilk basta bir collidera bas�l�yor olmal�, bas�ld�g�nda true olacak bir boolean kontrol edilecek.
    //collidera bas�ld��� anda type � bilinecek ve listeye eklenecek.
    //sonras�nda line olu�acak ve mouseposition u takip edecek. line �n max uzunlugu olacak
    //mouse position bir collidera denk geldiginde , typelar kars�last�r�lacak,
    //typelar uyu�uyorsa line renderer ilk collider olarak son dokunulan� sececek ve islem yeniden baslayacak
    //collider say�s� ��ten fazlaysa tamamd�r kardes diyecek

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
                Debug.Log("bu iki obje ayn� t�rden degil birle�emez");
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