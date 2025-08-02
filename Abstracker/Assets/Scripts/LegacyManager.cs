using UnityEngine;
using UnityEngine.SceneManagement;

public class LegacyManager : MonoBehaviour
{
    public Score score;
    public AutoClicker autoClicker;

    public int legacyPoints = 0;
    public int totalLegacyRuns = 0;

    public int puntosParaLegacy = 50000;

    void Start()
    {
        // Cargar legacy si existe
        legacyPoints = PlayerPrefs.GetInt("LegacyPoints", 0);
        totalLegacyRuns = PlayerPrefs.GetInt("TotalLegacyRuns", 0);
    }

    public void IntentarLegacy()
    {
        if (score.Points >= puntosParaLegacy)
        {
            legacyPoints += Mathf.FloorToInt(score.Points / 10000);
            totalLegacyRuns++;

            // Guardar legacy antes de reiniciar
            PlayerPrefs.SetInt("LegacyPoints", legacyPoints);
            PlayerPrefs.SetInt("TotalLegacyRuns", totalLegacyRuns);
            PlayerPrefs.Save();

            // Reiniciar escena
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
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
