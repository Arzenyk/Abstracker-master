using System.Collections;
using UnityEngine;

public class AutoClicker : MonoBehaviour
{
    public Score score;
    public float baseCPS = 0f;
    public float multiplier = 1f;

    void Start()
    {
        // Aplicar bonus legacy si existe
        float legacyMultiplier = PlayerPrefs.GetInt("LegacyPoints", 0) * 0.1f;
        multiplier = 1f + legacyMultiplier;

        StartCoroutine(AutoAddPoints());
    }


    IEnumerator AutoAddPoints()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            int pointsToAdd = Mathf.FloorToInt(baseCPS * multiplier);
            score.AddPoints(pointsToAdd);
        }
    }

    public void AddBaseCPS(float amount)
    {
        baseCPS += amount;
    }

    public void SetMultiplier(float value)
    {
        multiplier = value;
    }

    public float GetMultiplier()
    {
        return multiplier;
    }

    public void SetCPS(float value)
    {
        baseCPS = value;
    }

}
