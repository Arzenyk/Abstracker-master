using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorito : MonoBehaviour
{
    private Transform target;
    private MeteorSpawner spawner;
    private float speed = 10f;

    public void Inicializar(Transform objetivo, MeteorSpawner origen)
    {
        target = objetivo;
        spawner = origen;
    }

    void Update()
    {
        if (target == null) return;

        // Movimiento hacia el planeta
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        // Si llega al planeta
        if (Vector3.Distance(transform.position, target.position) < 0.5f)
        {
            spawner.ImpactoMeteorito();
            Destroy(gameObject);
        }
    }
}
