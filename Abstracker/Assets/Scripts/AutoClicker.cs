using System.Collections;
using UnityEngine;

public class AutoClicker : MonoBehaviour
{
    public Score score;
    public float baseCPS = 0f;
    public float multiplier = 1f;

    void Start()
    {
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

    public void AddMultiplier(float amount)
    {
        multiplier += amount;
    }
}
