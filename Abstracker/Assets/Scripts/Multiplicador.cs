using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiplicador : MonoBehaviour
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

    public void AddVPS(float amount)
    {
        pointsPerSecond += amount;
    }
}
