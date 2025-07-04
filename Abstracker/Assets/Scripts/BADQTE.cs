using UnityEngine;
using System.Collections;
using TMPro;

public class BADQTE : MonoBehaviour
{
    public GameObject badqteObject;
    public Score score;
    public AutoClicker autoClicker;

    public float badqteCooldown = 10f;

    private bool badqteActive = false;
    public float badqteActiveDuration = 3f;

    void Start()
    {
        badqteObject.SetActive(false);
        StartCoroutine(BADQTECountdown());
    }

    void Update()
    {
        if (!badqteActive) return;

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
            if (hit.collider.gameObject == badqteObject)
                OnBADQTEClicked();
        }
    }

    IEnumerator BADQTECountdown()
    {
        while (true)
        {
            yield return new WaitForSeconds(badqteCooldown);
            ActivateBADQTE();
        }
    }

    void ActivateBADQTE()
    {
        badqteActive = true;

        // Mover en X aleatoriamente entre -5 y 5, mantener Y y Z actuales
        Vector3 currentPos = badqteObject.transform.position;
        float randomX = Random.Range(-5f, 5f);
        badqteObject.transform.position = new Vector3(randomX, currentPos.y, currentPos.z);

        badqteObject.SetActive(true);
        StartCoroutine(BADQTEExpireCountdown());
    }

    IEnumerator BADQTEExpireCountdown()
    {
        float timer = badqteActiveDuration;

        while (timer > 0f && badqteActive)
        {
            timer -= Time.deltaTime;
            yield return null;
        }

        if (badqteActive)
        {
            badqteObject.SetActive(false);
            badqteActive = false;
        }
    }

    void OnBADQTEClicked()
    {
        if (!badqteActive) return;

        badqteActive = false;
        badqteObject.SetActive(false);
        score.AddPoints(-1000);
    }
}