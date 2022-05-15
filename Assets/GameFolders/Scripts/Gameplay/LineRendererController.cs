using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LineRenderer))]
public class LineRendererController : MonoBehaviour
{
    public static LineRendererController instance;
    //ilk basta bir collidera bas�l�yor olmal�, bas�ld�g�nda true olacak bir boolean kontrol edilecek.
    //collidera bas�ld��� anda type � bilinecek ve listeye eklenecek.
    //sonras�nda line olu�acak ve mouseposition u takip edecek. line �n max uzunlugu olacak
    //mouse position bir collidera denk geldiginde , typelar kars�last�r�lacak,
    //typelar uyu�uyorsa line renderer ilk collider olarak son dokunulan� sececek ve islem yeniden baslayacak
    //collider say�s� ��ten fazlaysa tamamd�r kardes diyecek

    private LineRenderer lineRenderer;

    public List<Transform> colliderList = new List<Transform>();
    void Awake()
    {
        instance = this;
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void ColliderListController(Transform objTransform)
    {
        if (colliderList.Count>0)
        {
            if (objTransform.GetComponent<Interactable>().type != colliderList[0].GetComponent<Interactable>().type)
            {
                Debug.Log("bu iki obje ayn� t�rden degil birle�emez");
            }
            else
            {
                colliderList.Add(objTransform);
            }
        }

        else
        {
            colliderList.Add(objTransform);
        }

    }
}
