using UnityEngine;
using System.Collections;
using TMPro;

public class QTEManager : MonoBehaviour
{
    public GameObject qteObject;
    public Score score;
    public AutoClicker autoClicker;

    public float boostMultiplier = 2f;
    public float boostDuration = 30f;
    public float qteCooldown = 10f;

    public TextMeshProUGUI bonusTimerText;

    private bool qteActive = false;
    public float qteActiveDuration = 3f;

    void Start()
    {
        qteObject.SetActive(false);
        bonusTimerText.text = "";
        StartCoroutine(QTECountdown());
    }

    void Update()
    {
        if (!qteActive) return;

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
            CheckTouch(Input.mousePosition);
#else
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            CheckTouch(Input.GetTouch(0).position);
#endif
    }

    void CheckTouch(Vector2 screenPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.gameObject == qteObject)
                OnQTEClicked();
        }
    }

    IEnumerator QTECountdown()
    {
        while (true)
        {
            yield return new WaitForSeconds(qteCooldown);
            ActivateQTE();
        }
    }

    void ActivateQTE()
    {
        qteActive = true;
        qteObject.SetActive(true);
        StartCoroutine(QTEExpireCountdown());
    }

    IEnumerator QTEExpireCountdown()
    {
        float timer = qteActiveDuration;

        while (timer > 0f && qteActive)
        {
            timer -= Time.deltaTime;
            yield return null;
        }

        if (qteActive)
        {
            qteObject.SetActive(false);
            qteActive = false;
        }
    }

    void OnQTEClicked()
    {
        if (!qteActive) return;

        qteActive = false;
        qteObject.SetActive(false);
        StartCoroutine(ApplyBoost());
    }

    IEnumerator ApplyBoost()
    {
        float originalMultiplier = autoClicker.multiplier;
        autoClicker.multiplier *= boostMultiplier;

        float remaining = boostDuration;

        while (remaining > 0f)
        {
            bonusTimerText.text = $" x{boostMultiplier}: {Mathf.CeilToInt(remaining)}s";
            yield return new WaitForSeconds(1f);
            remaining -= 1f;
        }

        bonusTimerText.text = "";
        autoClicker.multiplier = originalMultiplier;
    }
}