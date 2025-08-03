using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Planetas : MonoBehaviour
{
    public Score score;
    public AutoClicker autoClicker;

    public Button polvoButton, meteoroButton, lunaButton, planetaButton, estrellaButton, agujeroNegroButton ;
    public TMP_Text multiplicadorTxt;
    public TMP_Text polvoCostTxt, meteoroCostTxt, lunaCostTxt, planetaCostTxt, estrellaCostTxt, agujeroNegroCostTxt;

    int polvoCost = 10000, meteoroCost = 20000, lunaCost = 30000, planetaCost = 40000, estrellaCost = 50000, agujeroNegroCost = 60000;

    public GameObject polvo, meteoro, luna, planeta, estrella, agujeroNegro;
    public GameObject planetaUI;
    public GameObject planetas3D;

    public Button PlanetasButton;

    public GameObject Flechas;

    void Start()
    {
        polvoButton.onClick.RemoveAllListeners();
        meteoroButton.onClick.RemoveAllListeners();
        lunaButton.onClick.RemoveAllListeners();
        planetaButton.onClick.RemoveAllListeners();
        estrellaButton.onClick.RemoveAllListeners();
        agujeroNegroButton.onClick.RemoveAllListeners();
        PlanetasButton.onClick.RemoveAllListeners();

        polvoButton.onClick.AddListener(ComprarPolvo);
        meteoroButton.onClick.AddListener((ComprarMeteoro));
        lunaButton.onClick.AddListener(ComprarLuna);
        planetaButton.onClick.AddListener(ComprarPlaneta);
        estrellaButton.onClick.AddListener(ComprarEstrella);
        agujeroNegroButton.onClick.AddListener(ComprarAgujeroNegro);
        PlanetasButton.onClick.AddListener(PlanetasButtonClicked);

        meteoroButton.interactable = false;
        lunaButton.interactable = false;
        planetaButton.interactable = false;
        estrellaButton.interactable = false;
        agujeroNegroButton.interactable = false;

        autoClicker.SetMultiplier(1f); // Valor base
        UpdateMultiplicadorText();

        // Inicializar el texto del multiplicador
        multiplicadorTxt.text = "Multiplicador: x" + autoClicker.multiplier.ToString("0.0");
        polvoCostTxt.text = "Costo: " + polvoCost;
        meteoroCostTxt.text = "Costo: " + meteoroCost;
        lunaCostTxt.text = "Costo: " + lunaCost;
        planetaCostTxt.text = "Costo: " + planetaCost;
        estrellaCostTxt.text = "Costo: " + estrellaCost;
        agujeroNegroCostTxt.text = "Costo: " + agujeroNegroCost;
    }

    void ComprarPolvo()
    {
        if (score.Points >= polvoCost)
        {
            score.AddPoints(-polvoCost);
            autoClicker.SetMultiplier(2f);
            polvoButton.interactable = false;
            meteoroButton.interactable = true;
            UpdateMultiplicadorText();
            polvo.SetActive(true);
            polvoCostTxt.enabled = false; // Desactiva el texto de costo de polvo
        }
    }

    void ComprarMeteoro()
    {
        if (score.Points >= meteoroCost)
        {
            score.AddPoints(-meteoroCost);
            autoClicker.SetMultiplier(3f);
            meteoroButton.interactable = false;
            lunaButton.interactable = true;
            UpdateMultiplicadorText();
            meteoro.SetActive(true);
            polvo.SetActive(false);
            meteoroCostTxt.enabled = false; // Desactiva el texto de costo de meteoro
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
            meteoro.SetActive(false);
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
            estrellaButton.interactable = true;
            UpdateMultiplicadorText();
            luna.SetActive(false);
            planeta.SetActive(true);
            planetaCostTxt.enabled = false; // Desactiva el texto de costo de planeta
        }
    }

    void ComprarEstrella()
    {
        if (score.Points >= estrellaCost)
        {
            score.AddPoints(-estrellaCost);
            autoClicker.SetMultiplier(8f);
            estrellaButton.interactable = false;
            agujeroNegroButton.interactable = true;
            UpdateMultiplicadorText();
            planeta.SetActive(false);
            estrella.SetActive(true);
            estrellaCostTxt.enabled = false; // Desactiva el texto de costo de estrella
        }
    }

    void ComprarAgujeroNegro()
    {
        if (score.Points >= agujeroNegroCost)
        {
            score.AddPoints(-agujeroNegroCost);
            autoClicker.SetMultiplier(10f);
            agujeroNegroButton.interactable = false;
            UpdateMultiplicadorText();
            estrella.SetActive(false);
            agujeroNegro.SetActive(true);
            agujeroNegroCostTxt.enabled = false; // Desactiva el texto de costo de Agujero Negro
        }
    }

    void UpdateMultiplicadorText()
    {
        multiplicadorTxt.text = "Multiplicador: x" + autoClicker.multiplier.ToString("0.0");
    }

    void PlanetasButtonClicked()
    {
        MostrarPlanetas();
        PlanetasButton.gameObject.SetActive(false);
        Flechas.SetActive(true);
    }

    public void MostrarPlanetas()
    {
        planetaUI.SetActive(true);
        planetas3D.SetActive(true);
    }
}
