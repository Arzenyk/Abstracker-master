using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Menu : MonoBehaviour
{
    public Button jugar;

    private void Start()
    {
        jugar.onClick.AddListener(Jugar);
    }

    void Jugar()
    {
        SceneManager.LoadScene("abstrackerScene");
    }
}
