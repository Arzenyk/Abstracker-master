using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Planetas : MonoBehaviour
{
    public Score score;
    public AutoClicker autoClicker;

    public Button polvoButton, lunaButton, planetaButton;
    public TMP_Text multiplicadorTxt;
    public TMP_Text polvoCostTxt, lunaCostTxt, planetaCostTxt;

    int polvoCost = 10, lunaCost = 100, planetaCost = 1000;

    public GameObject polvo, luna, planeta;

    void Start()
    {
        polvoButton.onClick.RemoveAllListeners();
        lunaButton.onClick.RemoveAllListeners();
        planetaButton.onClick.RemoveAllListeners();

        polvoButton.onClick.AddListener(ComprarPolvo);
        lunaButton.onClick.AddListener(ComprarLuna);
        planetaButton.onClick.AddListener(ComprarPlaneta);

        lunaButton.interactable = false;
        planetaButton.interactable = false;

        autoClicker.SetMultiplier(1f); // Valor base
        UpdateMultiplicadorText();

        // Inicializar el texto del multiplicador
        multiplicadorTxt.text = "Multiplicador: x" + autoClicker.multiplier.ToString("0.0");
        polvoCostTxt.text = "Costo: " + polvoCost;
        lunaCostTxt.text = "Costo: " + lunaCost;
        planetaCostTxt.text = "Costo: " + planetaCost;
    }

    void ComprarPolvo()
    {
        if (score.Points >= polvoCost)
        {
            score.AddPoints(-polvoCost);
            autoClicker.SetMultiplier(2f);
            polvoButton.interactable = false;
            lunaButton.interactable = true;
            UpdateMultiplicadorText();
            polvo.SetActive(true);
            polvoCostTxt.enabled = false; // Desactiva el texto de costo de polvo
        }
    }

    void ComprarLuna()
    {
        if (score.Points >= lunaCost)
        {
            score.AddPoints(-lunaCost);
            autoClicker.SetMultiplier(4f);
            lunaButton.interactable = false;
            planetaButton.interactable = true;
            UpdateMultiplicadorText();
            polvo.SetActive(false);
            luna.SetActive(true);
            lunaCostTxt.enabled = false; // Desactiva el texto de costo de luna
        }
    }

    void ComprarPlaneta()
    {
        if (score.Points >= planetaCost)
        {
            score.AddPoints(-planetaCost);
            autoClicker.SetMultiplier(6f);
            planetaButton.interactable = false;
            UpdateMultiplicadorText();
            luna.SetActive(false);
            planeta.SetActive(true);
            planetaCostTxt.enabled = false; // Desactiva el texto de costo de planeta
        }
    }

    void UpdateMultiplicadorText()
    {
        multiplicadorTxt.text = "Multiplicador: x" + autoClicker.multiplier.ToString("0.0");
    }
}
