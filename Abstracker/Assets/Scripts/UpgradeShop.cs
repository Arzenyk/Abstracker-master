using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeShop : MonoBehaviour
{
    public Score score;
    public AutoClicker autoClicker;

    public Button Punto;
    public Button Linea;
    public Button Triangulo;

    public GameObject linea;
    public GameObject punto;
    public GameObject triangulo;

    public TMP_Text puntoUpgrade;
    public TMP_Text lineaUpgrade;
    public TMP_Text trianguloUpgrade;

    public TMP_Text puntoCosto;
    public TMP_Text lineaCosto;
    public TMP_Text trianguloCosto;

    private int PuntoUpgradeLevel = 0;
    private int LineaUpgradeLevel = 0;
    private int TrianguloUpgradeLevel = 0;

    private int PuntoCost = 10;
    private int LineaCost = 100;
    private int TrianguloCost = 1000;

    bool PrimerLinea = true;
    bool PrimerTriangulo = true;

    void Start()
    {
        Punto.onClick.AddListener(ComprarPunto);
        Linea.onClick.AddListener(ComprarLinea);
        Triangulo.onClick.AddListener(ComprarTriangulo);

        puntoUpgrade.text = PuntoUpgradeLevel.ToString();
        lineaUpgrade.text = LineaUpgradeLevel.ToString();
        trianguloUpgrade.text = TrianguloUpgradeLevel.ToString();

        puntoCosto.text = GetCostPunto().ToString();
        lineaCosto.text = GetCostLinea().ToString();
        trianguloCosto.text = GetCostTriangulo().ToString();

    }

    void ComprarPunto()
    {
        int cost = GetCostPunto();

        if (score.Points >= cost)
        {
            score.AddPoints(-cost); // restamos
            PuntoUpgradeLevel++;
            autoClicker.AddCPS(1f); // 1 punto por segundo
        }

        puntoUpgrade.text = PuntoUpgradeLevel.ToString();
        puntoCosto.text = GetCostPunto().ToString();
    }

    void ComprarLinea()
    {
        if (PrimerLinea)
        {
            linea.SetActive(true);
            punto.SetActive(false);
            PrimerLinea = false;
        }

        int cost = GetCostLinea();
        if (score.Points >= cost)
        {
            score.AddPoints(-cost); // restamos
            LineaUpgradeLevel++;
            autoClicker.AddCPS(2f); // 2 punto por segundo
            score.AddClickValue(1); // 1 puntos por clic
        }

        lineaUpgrade.text = LineaUpgradeLevel.ToString();
        lineaCosto.text = GetCostLinea().ToString();

    }

    void ComprarTriangulo()
    {
        if (PrimerTriangulo)
        {
            triangulo.SetActive(true);
            linea.SetActive(false);
            PrimerTriangulo = false;
        }

        int cost = GetCostTriangulo();
        if (score.Points >= cost)
        {
            score.AddPoints(-cost); // restamos
            TrianguloUpgradeLevel++;
            autoClicker.AddCPS(4f); // 4 punto por segundo
            score.AddClickValue(2); // 2 puntos por clic
        }

        trianguloUpgrade.text = TrianguloUpgradeLevel.ToString();
        trianguloCosto.text = GetCostTriangulo().ToString();

    }

    int GetCostPunto()
    {
        return PuntoCost * (PuntoUpgradeLevel + 1);
    }

    int GetCostLinea()
    {
        return LineaCost * (LineaUpgradeLevel + 1);
    }

    int GetCostTriangulo()
    {
        return TrianguloCost * (TrianguloUpgradeLevel + 1);
    }
}
