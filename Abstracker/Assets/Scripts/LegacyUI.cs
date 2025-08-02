using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LegacyUI : MonoBehaviour
{
    public LegacyManager legacyManager;
    public Score score;
    public TMP_Text legacyInfoText;
    public Button legacyButton;

    public int puntosParaLegacy = 50000;

    void Start()
    {
        legacyButton.onClick.AddListener(legacyManager.IntentarLegacy);
    }

    void Update()
    {
        if (score.Points >= puntosParaLegacy)
        {

            int legacy = legacyManager.GetLegacyPoints();
            float bonus = legacyManager.GetLegacyBonusMultiplier();

            legacyInfoText.text = $"Legacy Points: {legacy} | Bonus: x{bonus:F1}";
        }
    }
}
