using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hh : MonoBehaviour
{
    public GameObject objectToDestroy;

    void Update()
    {
        // Örneğin, bir tuşa basıldığında objeyi yok etmek için
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DestroyObject();
        }
    }

    void DestroyObject()
    {
        // GameObject.Destroy() veya kısa şekliyle Destroy() kullanabilirsiniz.
        Destroy(objectToDestroy);
    }
}
