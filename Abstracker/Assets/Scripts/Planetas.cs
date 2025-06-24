using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Planetas : MonoBehaviour
{
    public Score score;
    public Multiplicador multiplicador;

    public Button polvoButton;
    public Button lunaButton;
    public Button planetaButton;

    public GameObject polvo;
    public GameObject luna;
    public GameObject planeta;

    public TMP_Text polvoCosto;
    public TMP_Text lunaCosto;
    public TMP_Text planetaCosto;

    public TMP_Text multiplicadorTxt;

    private int polvoCost = 10;
    private int lunaCost = 100;
    private int planetaCost = 1000;

    public int numMultiplicador;

    void Start()
    {
        polvoButton.onClick.AddListener(ComprarPolvo);
        lunaButton.onClick.AddListener(ComprarLuna);
        planetaButton.onClick.AddListener(ComprarPlaneta);

        polvoCosto.text = GetCostPolvo().ToString();
        lunaCosto.text = GetCostLuna().ToString();
        planetaCosto.text = GetCostPlaneta().ToString();

        polvoButton.enabled = true;
        lunaButton.enabled = false;
        planetaButton.enabled = false;

        multiplicadorTxt.text = "Multiplicador: " + multiplicador.pointsPerSecond.ToString("0.0");
    }

    void ComprarPolvo()
    {
        int cost = GetCostPolvo();
        
        if (score.Points >= cost)
        {
            score.AddPoints(-cost);
            multiplicador.AddVPS(2f);
            multiplicador.pointsPerSecond.ToString();

            lunaButton.enabled = true;
            polvoButton.enabled = false;
            polvo.SetActive(true);

            multiplicadorTxt.text = "Multiplicador: " + multiplicador.pointsPerSecond.ToString();
        }
        polvoCosto.enabled = false; // Deshabilitamos el texto de costo de polvo
    }

    void ComprarLuna()
    {
        int cost = GetCostLuna();

        if (score.Points >= cost)
        {
            score.AddPoints(-cost); // restamos
            multiplicador.AddVPS(4f); // 2 punto por segundo
            multiplicador.pointsPerSecond.ToString();

            lunaButton.enabled = false;
            planetaButton.enabled = true;
            luna.SetActive(true);
            polvo.SetActive(false);

            multiplicadorTxt.text = "Multiplicador: " + multiplicador.pointsPerSecond.ToString();
            
        }

        lunaCosto.enabled = false; // Deshabilitamos el texto de costo de luna

    }

    void ComprarPlaneta()
    {
        int cost = GetCostPlaneta();

        if (score.Points >= cost)
        {
            score.AddPoints(-cost); // restamos
            multiplicador.AddVPS(6f); // 4 punto por segundo
            multiplicador.pointsPerSecond.ToString();

            planetaButton.enabled = false;
            planeta.SetActive(true);
            luna.SetActive(false);
            polvo.SetActive(false);

            multiplicadorTxt.text = "Multiplicador: " + multiplicador.pointsPerSecond.ToString();
        }

        planetaCosto.enabled = false; // Deshabilitamos el texto de costo de planeta

    }

    int GetCostPolvo()
    {
        return polvoCost * (1);
    }

    int GetCostLuna()
    {
        return lunaCost * (1);
    }

    int GetCostPlaneta()
    {
        return planetaCost * (1);
    }
}
