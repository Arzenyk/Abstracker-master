using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeShop : MonoBehaviour
{
    public Score score;
    public AutoClicker autoClicker;
    public Planetas planetas;

    public Button Punto, Linea, Triangulo, Cuadrado;
    public TMP_Text puntoUpgrade, lineaUpgrade, trianguloUpgrade, cuadradoUpgrade;
    public TMP_Text puntoCosto, lineaCosto, trianguloCosto, cuadradoCosto;

    private int PuntoUpgradeLevel = 0, LineaUpgradeLevel = 0, TrianguloUpgradeLevel = 0, CuadradoUpgradeLevel = 0;
    private int PuntoCost = 10, LineaCost = 100, TrianguloCost = 1000, CuadradoCost = 10000;

    public GameObject punto;
    public GameObject linea;
    public GameObject triangulo;
    public GameObject cuadrado;

    private int nivelVisualActual = 0; // 0 = punto, 1 = línea, 2 = triángulo, 3 = cuadrado

    public Button PlanetasButton;


    void Start()
    {
        Punto.onClick.RemoveAllListeners();
        Punto.onClick.AddListener(ComprarPunto);

        Linea.onClick.RemoveAllListeners();
        Linea.onClick.AddListener(ComprarLinea);
        
        Triangulo.onClick.RemoveAllListeners();
        Triangulo.onClick.AddListener(ComprarTriangulo);
        
        Cuadrado.onClick.RemoveAllListeners();
        Cuadrado.onClick.AddListener(ComprarCuadrado);

        punto.SetActive(true);
        linea.SetActive(false);
        triangulo.SetActive(false);
        cuadrado.SetActive(false);



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

            if (nivelVisualActual < 1)
            {
                punto.SetActive(false);
                linea.SetActive(true);
                triangulo.SetActive(false);
                cuadrado.SetActive(false);
                nivelVisualActual = 1;
            }

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
            PlanetasButton.gameObject.SetActive(true);

            if (nivelVisualActual < 2)
            {
                punto.SetActive(false);
                linea.SetActive(false);
                triangulo.SetActive(true);
                cuadrado.SetActive(false);
                nivelVisualActual = 2;
                
            }

            ActualizarTexto();
        }
    }


    void ComprarCuadrado()
    {
        int cost = CuadradoCost * (CuadradoUpgradeLevel + 1);
        if (score.Points >= cost)
        {
            score.AddPoints(-cost);
            CuadradoUpgradeLevel++;
            autoClicker.AddBaseCPS(8f);
            score.AddClickValue(4);

            if (nivelVisualActual < 3)
            {
                punto.SetActive(false);
                linea.SetActive(false);
                triangulo.SetActive(false);
                cuadrado.SetActive(true);
                nivelVisualActual = 3;
            }

            ActualizarTexto();
        }
    }


    void ActualizarTexto()
    {
        puntoUpgrade.text = $"Nivel: {PuntoUpgradeLevel}";
        lineaUpgrade.text = $"Nivel: {LineaUpgradeLevel}";
        trianguloUpgrade.text = $"Nivel: {TrianguloUpgradeLevel}";
        cuadradoUpgrade.text = $"Nivel: {CuadradoUpgradeLevel}";

        puntoCosto.text = $"Costo: {PuntoCost * (PuntoUpgradeLevel + 1)}";
        lineaCosto.text = $"Costo: {LineaCost * (LineaUpgradeLevel + 1)}";
        trianguloCosto.text = $"Costo: {TrianguloCost * (TrianguloUpgradeLevel + 1)}";
        cuadradoCosto.text = $"Costo: {CuadradoCost * (CuadradoUpgradeLevel + 1)}";
    }
}
