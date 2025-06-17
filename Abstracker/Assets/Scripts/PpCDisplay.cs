using UnityEngine;
using TMPro;

public class PpCDisplay : MonoBehaviour
{
    public Score score;
    public TextMeshProUGUI ppcText;

    void Update()
    {
        ppcText.text = "VpC: " + score.ClickValue.ToString();
    }
}
