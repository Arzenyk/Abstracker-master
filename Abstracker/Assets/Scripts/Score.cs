using UnityEngine;

public class Score : MonoBehaviour
{
    public int Points { get; private set; } = 0;
    public int ClickValue { get; private set; } = 1;

    public void AddPoint()
    {
        Points += ClickValue;
    }

    public void AddPoints(int amount)
    {
        Points += amount;
    }

    public void AddClickValue(int amount)
    {
        ClickValue += amount;
    }
}
