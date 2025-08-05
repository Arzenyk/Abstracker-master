using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class UpgradeShop : MonoBehaviour
{
    public Score score;
    public AutoClicker autoClicker;
    public Planetas planetas;

    public Button Punto, Linea, Triangulo, Cuadrado, Geodesic, Rombo;
    public TMP_Text puntoUpgrade, lineaUpgrade, trianguloUpgrade, cuadradoUpgrade, geodesicUpgrade, romboUpgrade;
    public TMP_Text puntoCosto, lineaCosto, trianguloCosto, cuadradoCosto, geodesicCosto, romboCosto;

    private int PuntoUpgradeLevel = 0, LineaUpgradeLevel = 0, TrianguloUpgradeLevel = 0, CuadradoUpgradeLevel = 0, GeodesicUpgradeLevel = 0, RomboUpgradeLevel = 0;
    private int PuntoCost = 10, LineaCost = 100, TrianguloCost = 1000, CuadradoCost = 10000, GeodesicCost = 20000, RomboCost = 30000;

    public GameObject punto, linea, triangulo, cuadrado, geodesic, rombo;


    private int nivelVisualActual = 0; // 0 = punto, 1 = línea, 2 = triángulo, 3 = cuadrado, 4 = geodesic, 5 = rombo

    public Button PlanetasButton;

    public Button dimensionButton; // Asigná en el Inspector
    private bool dimensionUnlocked = false;

    public GameObject cuadradoRotante;
    public GameObject geodesicRotante;
    public GameObject romboRotante;



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

        Geodesic.onClick.RemoveAllListeners();
        Geodesic.onClick.AddListener(ComprarGeodesic);

        Rombo.onClick.RemoveAllListeners();
        Rombo.onClick.AddListener(ComprarRombo);

        punto.SetActive(true);
        linea.SetActive(false);
        triangulo.SetActive(false);
        cuadrado.SetActive(false);
        geodesic.SetActive(false);
        rombo.SetActive(false);



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

        if (CuadradoUpgradeLevel >= 10 && !dimensionUnlocked)
        {
            dimensionUnlocked = true;
            dimensionButton.gameObject.SetActive(true);
        }

    }

    void ComprarGeodesic()
    {
        int cost = GeodesicCost * (GeodesicUpgradeLevel + 1);
        if (score.Points >= cost)
        {
            score.AddPoints(-cost);
            GeodesicUpgradeLevel++;
            autoClicker.AddBaseCPS(16f);
            score.AddClickValue(8);

            if (nivelVisualActual < 4)
            {
                punto.SetActive(false);
                linea.SetActive(false);
                triangulo.SetActive(false);
                cuadrado.SetActive(false);
                geodesic.SetActive(true);
                nivelVisualActual = 4;
            }

            geodesicRotante.AddComponent<RotarObjeto>();
            ActualizarTexto();
        }
    }

    void ComprarRombo()
    {
        int cost = RomboCost * (RomboUpgradeLevel + 1);
        if (score.Points >= cost)
        {
            score.AddPoints(-cost);
            RomboUpgradeLevel++;
            autoClicker.AddBaseCPS(32f);
            score.AddClickValue(16);

            if (nivelVisualActual < 5)
            {
                punto.SetActive(false);
                linea.SetActive(false);
                triangulo.SetActive(false);
                cuadrado.SetActive(false);
                geodesic.SetActive(false);
                rombo.SetActive(true);
                nivelVisualActual = 5;
            }
            romboRotante.AddComponent<RotarObjeto>();
            ActualizarTexto();
        }
    }


    void ActualizarTexto()
    {
        puntoUpgrade.text = $"Nivel: {PuntoUpgradeLevel}";
        lineaUpgrade.text = $"Nivel: {LineaUpgradeLevel}";
        trianguloUpgrade.text = $"Nivel: {TrianguloUpgradeLevel}";
        cuadradoUpgrade.text = $"Nivel: {CuadradoUpgradeLevel}";
        geodesicUpgrade.text = $"Nivel: {GeodesicUpgradeLevel}";
        romboUpgrade.text = $"Nivel: {RomboUpgradeLevel}";

        puntoCosto.text = $"Costo: {PuntoCost * (PuntoUpgradeLevel + 1)}";
        lineaCosto.text = $"Costo: {LineaCost * (LineaUpgradeLevel + 1)}";
        trianguloCosto.text = $"Costo: {TrianguloCost * (TrianguloUpgradeLevel + 1)}";
        cuadradoCosto.text = $"Costo: {CuadradoCost * (CuadradoUpgradeLevel + 1)}";
        geodesicCosto.text = $"Costo: {GeodesicCost * (GeodesicUpgradeLevel + 1)}";
        romboCosto.text = $"Costo: {RomboCost * (RomboUpgradeLevel + 1)}";
    }

    public void PasarASiguienteDimension()
    {
        if (cuadradoRotante != null)
        {
            cuadradoRotante.AddComponent<RotarObjeto>();
        }

        dimensionButton.gameObject.SetActive(false);
    }

}
