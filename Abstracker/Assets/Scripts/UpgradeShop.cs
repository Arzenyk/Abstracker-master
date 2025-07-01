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

    int PuntoUpgradeLevel = 0, LineaUpgradeLevel = 0, TrianguloUpgradeLevel = 0;
    int PuntoCost = 10, LineaCost = 100, TrianguloCost = 1000;

    void Start()
    {
        Punto.onClick.AddListener(ComprarPunto);
        Linea.onClick.AddListener(ComprarLinea);
        Triangulo.onClick.AddListener(ComprarTriangulo);

        ActualizarTexto();
    }

    void ComprarPunto()
    {
        int cost = PuntoCost * (PuntoUpgradeLevel + 1);
        if (score.Points >= cost)
        {
            score.AddPoints(-cost);
            PuntoUpgradeLevel++;
            autoClicker.AddBaseCPS(1f);
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
        }
        ActualizarTexto();
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
        }
        ActualizarTexto();
    }

    void ActualizarTexto()
    {
        puntoUpgrade.text = PuntoUpgradeLevel.ToString();
        lineaUpgrade.text = LineaUpgradeLevel.ToString();
        trianguloUpgrade.text = TrianguloUpgradeLevel.ToString();

        puntoCosto.text = (PuntoCost * (PuntoUpgradeLevel + 1)).ToString();
        lineaCosto.text = (LineaCost * (LineaUpgradeLevel + 1)).ToString();
        trianguloCosto.text = (TrianguloCost * (TrianguloUpgradeLevel + 1)).ToString();
    }
}
