using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public Score score; // Asignar desde el Inspector
    public TextMeshProUGUI scoreText; // Asignar desde el Inspector

    void Update()
    {
        scoreText.text = "Vertices: " + score.Points.ToString();
    }
}
