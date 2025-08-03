using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class LegacyManager : MonoBehaviour
{
    public Score score;
    public AutoClicker autoClicker;

    public Button legacyButton;
    public TMP_Text legacyInfoText;

    public int legacyPoints = 0;
    public int totalLegacyRuns = 0;

    public int puntosParaLegacy = 1000000;

    void Start()
    {
        legacyPoints = PlayerPrefs.GetInt("LegacyPoints", 0);
        totalLegacyRuns = PlayerPrefs.GetInt("TotalLegacyRuns", 0);
        legacyInfoText.text = ""; // Asegura que empiece vacío
    }

    public void IntentarLegacy()
    {
        if (score.Points >= puntosParaLegacy)
        {
            legacyPoints += Mathf.FloorToInt(score.Points / 10000);
            totalLegacyRuns++;

            PlayerPrefs.SetInt("LegacyPoints", legacyPoints);
            PlayerPrefs.SetInt("TotalLegacyRuns", totalLegacyRuns);
            PlayerPrefs.Save();

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            StartCoroutine(MostrarMensajeTemporal("No tienes suficientes puntos para intentar un Legacy.\nNecesitas al menos 1.000.000 puntos.", 2f));
        }
    }

    private IEnumerator MostrarMensajeTemporal(string mensaje, float duracion)
    {
        legacyInfoText.text = mensaje;
        yield return new WaitForSeconds(duracion);
        legacyInfoText.text = "";
    }

    public int GetLegacyPoints()
    {
        return legacyPoints;
    }

    public float GetLegacyBonusMultiplier()
    {
        return 1f + legacyPoints * 0.1f;
    }
}
