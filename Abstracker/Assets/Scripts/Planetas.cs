using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Planetas : MonoBehaviour
{
    public Score score;
    public AutoClicker autoClicker;

    public Button polvoButton, lunaButton, planetaButton;
    public TMP_Text multiplicadorTxt;

    int polvoCost = 10, lunaCost = 100, planetaCost = 1000;

    void Start()
    {
        polvoButton.onClick.AddListener(ComprarPolvo);
        lunaButton.onClick.AddListener(ComprarLuna);
        planetaButton.onClick.AddListener(ComprarPlaneta);

        lunaButton.interactable = false;
        planetaButton.interactable = false;

        UpdateMultiplicadorText();
    }

    void ComprarPolvo()
    {
        if (score.Points >= polvoCost)
        {
            score.AddPoints(-polvoCost);
            autoClicker.AddMultiplier(1f);
            polvoButton.interactable = false;
            lunaButton.interactable = true;
            UpdateMultiplicadorText();
        }
    }

    void ComprarLuna()
    {
        if (score.Points >= lunaCost)
        {
            score.AddPoints(-lunaCost);
            autoClicker.AddMultiplier(3f);
            lunaButton.interactable = false;
            planetaButton.interactable = true;
            UpdateMultiplicadorText();
        }
    }

    void ComprarPlaneta()
    {
        if (score.Points >= planetaCost)
        {
            score.AddPoints(-planetaCost);
            autoClicker.AddMultiplier(5f);
            planetaButton.interactable = false;
            UpdateMultiplicadorText();
        }
    }

    void UpdateMultiplicadorText()
    {
        multiplicadorTxt.text = "Multiplicador: " + autoClicker.multiplier.ToString("0.0");
    }
}
