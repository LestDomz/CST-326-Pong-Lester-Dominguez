using UnityEngine;
using TMPro;
using System.Collections;

public class FloatingText : MonoBehaviour
{
    public float displayTime = 1.5f; // Time before disappearing
    private TextMeshProUGUI textMesh;
    private CanvasGroup canvasGroup;

    void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void ShowMessage(string message, Vector3 position)
    {
        textMesh.text = message;
        transform.position = Camera.main.WorldToScreenPoint(position); // Convert world position to UI position
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(displayTime);

        float fadeDuration = 0.5f;
        float fadeSpeed = 1f / fadeDuration;
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= fadeSpeed * Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
}
