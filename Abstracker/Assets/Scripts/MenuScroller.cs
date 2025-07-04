using UnityEngine;
using UnityEngine.UI;

public class MenuScroller : MonoBehaviour
{
    public RectTransform menuUI;
    public Transform[] objetos3D;

    public Button botonSiguiente;
    public Button botonAnterior;

    public float stepUI = 500f;
    public float stepWorld = 5f;

    private int stepActual = 0;
    private int maxSteps = 4;

    private Vector3[] posicionesIniciales3D;

    void Start()
    {
        // Guardamos las posiciones originales de los objetos 3D
        posicionesIniciales3D = new Vector3[objetos3D.Length];
        for (int i = 0; i < objetos3D.Length; i++)
        {
            posicionesIniciales3D[i] = objetos3D[i].position;
        }

        // Conectamos los botones
        botonSiguiente.onClick.AddListener(() => MoverA(stepActual + 1));
        botonAnterior.onClick.AddListener(() => MoverA(stepActual - 1));

        // Posición inicial
        ActualizarPosiciones();
    }

    void MoverA(int nuevoStep)
    {
        // Límite inferior y superior
        if (nuevoStep < 0 || nuevoStep > maxSteps) return;

        stepActual = nuevoStep;
        ActualizarPosiciones();
    }

    void ActualizarPosiciones()
    {
        // Mover UI de golpe
        float nuevaXUI = -stepActual * stepUI;
        menuUI.anchoredPosition = new Vector2(nuevaXUI, menuUI.anchoredPosition.y);

        // Mover todos los objetos 3D también de golpe
        float desplazamientoX = stepActual * stepWorld;
        for (int i = 0; i < objetos3D.Length; i++)
        {
            objetos3D[i].position = posicionesIniciales3D[i] - new Vector3(desplazamientoX, 0, 0);
        }
    }
}
