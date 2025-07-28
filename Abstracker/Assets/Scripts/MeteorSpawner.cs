using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public TextMeshProUGUI dañoTexto; // Asignar en el inspector
    private Coroutine dañoCoroutine;
    public GameObject meteorPrefab;         // Prefab del meteorito
    public Transform spawnArea;             // Área sobre el planeta donde spawnean
    public Transform planetaTarget;         // Objetivo al que caen (el planeta)
    public float spawnInterval = 5f;        // Cada cuántos segundos cae uno

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
        // Posición aleatoria en X y Z, arriba del planeta
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
            MostrarDaño("-1 vida");
        }
        else if (escudoVida == 0)
        {
            score.AddPoints(-1000);
            MostrarDaño("-1000");
            escudo.SetActive(false);
            escudoActivo = false;
        }
    }

    public void MostrarDaño(string texto)
    {
        if (dañoCoroutine != null)
            StopCoroutine(dañoCoroutine);

        dañoCoroutine = StartCoroutine(MostrarDañoTemporal(texto));
    }

    IEnumerator MostrarDañoTemporal(string texto)
    {
        dañoTexto.text = texto;
        dañoTexto.gameObject.SetActive(true);

        yield return new WaitForSeconds(1.5f); // Tiempo visible

        dañoTexto.gameObject.SetActive(false);
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
