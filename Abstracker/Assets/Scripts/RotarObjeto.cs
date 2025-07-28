using UnityEngine;

public class RotarObjeto : MonoBehaviour
{
    public float velocidad = 90f; // grados por segundo

    void Update()
    {
        transform.Rotate(Vector3.up * velocidad * Time.deltaTime);
    }
}
