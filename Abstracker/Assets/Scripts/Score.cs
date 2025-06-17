using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int Points { get; private set; } = 0;

    public void AddPoint()
    {
        Points++;
    }
}