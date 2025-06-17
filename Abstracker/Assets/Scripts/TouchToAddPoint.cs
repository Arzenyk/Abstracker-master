using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchToAddPoint : MonoBehaviour
{
    public Score score; // Asignar desde el Inspector

    void Update()
    {
        // Solo en dispositivo móvil
        if (!Application.isEditor)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                score.AddPoint();
            }
        }

        // Solo en el editor para pruebas con mouse
        if (Application.isEditor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                score.AddPoint();
            }
        }
    }
}