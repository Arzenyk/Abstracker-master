using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public TextMeshProUGUI da�oTexto; // Asignar en el inspector
    private Coroutine da�oCoroutine;
    public GameObject meteorPrefab;         // Prefab del meteorito
    public Transform spawnArea;             // �rea sobre el planeta donde spawnean
    public Transform planetaTarget;         // Objetivo al que caen (el planeta)
    public float spawnInterval = 5f;        // Cada cu�ntos segundos cae uno

    public bool escudoActivo = false;       // Si el jugador tiene escudo
    public int escudoVida = 3;              // Vida del escudo
    public Score score;                     // Referencia al sistema de puntos

    public GameObject planeta;              // El planeta 3D que activa el sistema
    public GameObject escudo;

    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            if (planeta.activeSelf)
            {
                SpawnMeteor();
            }
        }
    }

    void SpawnMeteor()
    {
        // Posici�n aleatoria en X y Z, arriba del planeta
        float range = 5f;
        Vector3 spawnPos = new Vector3(
            Random.Range(-range, range),
            spawnArea.position.y,
            Random.Range(-range, range)
        );

        GameObject meteor = Instantiate(meteorPrefab, spawnPos, Quaternion.identity);
        meteor.AddComponent<Meteorito>().Inicializar(planetaTarget, this);
    }

    // Llamado por los meteoritos al impactar
    public void ImpactoMeteorito()
    {
        if (escudoActivo && escudoVida > 0)
        {
            escudoVida--;
            MostrarDa�o("-1 vida");
        }
        else if (escudoVida == 0)
        {
            score.AddPoints(-1000);
            MostrarDa�o("-1000");
            escudo.SetActive(false);
            escudoActivo = false;
        }
    }

    public void MostrarDa�o(string texto)
    {
        if (da�oCoroutine != null)
            StopCoroutine(da�oCoroutine);

        da�oCoroutine = StartCoroutine(MostrarDa�oTemporal(texto));
    }

    IEnumerator MostrarDa�oTemporal(string texto)
    {
        da�oTexto.text = texto;
        da�oTexto.gameObject.SetActive(true);

        yield return new WaitForSeconds(1.5f); // Tiempo visible

        da�oTexto.gameObject.SetActive(false);
    }
    public void ActivarEscudo()
    {
        if (score.Points >= 1000 && !escudoActivo)
        {
            escudo.SetActive(true);
            score.AddPoints(-1000);
            escudoActivo = true;
            escudoVida = 3;
        }
    }

    public void DesactivarEscudo()
    {
        escudo.SetActive(false);
        escudoActivo = false;
    }
}
