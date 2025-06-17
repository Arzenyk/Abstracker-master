using System.Collections;
using UnityEngine;

public class AutoClicker : MonoBehaviour
{
    public Score score;
    public float pointsPerSecond = 0f;

    void Start()
    {
        StartCoroutine(AutoAddPoints());
    }

    IEnumerator AutoAddPoints()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            score.AddPoints(Mathf.FloorToInt(pointsPerSecond));
        }
    }

    public void AddCPS(float amount)
    {
        pointsPerSecond += amount;
    }
}
