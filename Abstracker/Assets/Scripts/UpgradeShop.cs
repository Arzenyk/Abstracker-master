using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeShop : MonoBehaviour
{
    public Score score;
    public AutoClicker autoClicker;

    public Button Punto, Linea, Triangulo;
    public TMP_Text puntoUpgrade, lineaUpgrade, trianguloUpgrade;
    public TMP_Text puntoCosto, lineaCosto, trianguloCosto;

    private int PuntoUpgradeLevel = 0, LineaUpgradeLevel = 0, TrianguloUpgradeLevel = 0;
    private int PuntoCost = 10, LineaCost = 100, TrianguloCost = 1000;

    public GameObject punto;
    public GameObject linea;
    public GameObject triangulo;

    void Start()
    {
            Punto.onClick.RemoveAllListeners();
            Punto.onClick.AddListener(ComprarPunto);

            Linea.onClick.RemoveAllListeners();
            Linea.onClick.AddListener(ComprarLinea);

            Triangulo.onClick.RemoveAllListeners();
            Triangulo.onClick.AddListener(ComprarTriangulo);

            punto.SetActive(true);
            linea.SetActive(false);
            triangulo.SetActive(false);

            ActualizarTexto();
    }

    void ComprarPunto()
    {
        int cost = PuntoCost * (PuntoUpgradeLevel + 1);
        if (score.Points >= cost)
        {
            score.AddPoints(-cost);
            PuntoUpgradeLevel++;
            score.AddClickValue(1); // Aumenta puntos por clic, no CPS
        }

        ActualizarTexto();
    }

    void ComprarLinea()
    {
        int cost = LineaCost * (LineaUpgradeLevel + 1);
        if (score.Points >= cost)
        {
            score.AddPoints(-cost);
            LineaUpgradeLevel++;
            autoClicker.AddBaseCPS(2f);
            score.AddClickValue(1);
            punto.SetActive(false);
            linea.SetActive(true);
            ActualizarTexto();
        }
    }

    void ComprarTriangulo()
    {
        int cost = TrianguloCost * (TrianguloUpgradeLevel + 1);
        if (score.Points >= cost)
        {
            score.AddPoints(-cost);
            TrianguloUpgradeLevel++;
            autoClicker.AddBaseCPS(4f);
            score.AddClickValue(2);
            linea.SetActive(false);
            triangulo.SetActive(true);
            ActualizarTexto();
        }
    }

    void ActualizarTexto()
    {
        puntoUpgrade.text = $"Nivel: {PuntoUpgradeLevel}";
        lineaUpgrade.text = $"Nivel: {LineaUpgradeLevel}";
        trianguloUpgrade.text = $"Nivel: {TrianguloUpgradeLevel}";

        puntoCosto.text = $"Costo: {PuntoCost * (PuntoUpgradeLevel + 1)}";
        lineaCosto.text = $"Costo: {LineaCost * (LineaUpgradeLevel + 1)}";
        trianguloCosto.text = $"Costo: {TrianguloCost * (TrianguloUpgradeLevel + 1)}";
    }
}
