using UnityEngine;
using TMPro;

public class CPSDisplay : MonoBehaviour
{
    public AutoClicker autoClicker;
    public TextMeshProUGUI cpsText;

    void Update()
    {
        cpsText.text = "VpS: " + autoClicker.pointsPerSecond.ToString("0.0");
    }
}
