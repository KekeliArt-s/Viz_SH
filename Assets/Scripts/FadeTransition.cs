using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeTransition : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1.0f;

    private void Start()
    {
        if (fadeImage == null)
        {
            Debug.LogError("L'image de transition n'est pas assignée !");
        }
        // Assurez-vous que l'image de transition est invisible au départ
        fadeImage.color = new Color(0, 0, 0, 0);
    }

    public void StartFadeInOut()
    {
        StartCoroutine(FadeInOut());
    }

    private IEnumerator FadeInOut()
    {
        yield return StartCoroutine(Fade(1)); // Fade in
        // Ajouter une pause ou une action ici si nécessaire, par exemple téléporter le joueur
        yield return new WaitForSeconds(0.1f); // Courte pause
        yield return StartCoroutine(Fade(0)); // Fade out
    }

    private IEnumerator Fade(float targetAlpha)
    {
        float startAlpha = fadeImage.color.a;
        float time = 0;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, time / fadeDuration);
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        // Assurez-vous que l'alpha est exactement le targetAlpha à la fin
        fadeImage.color = new Color(0, 0, 0, targetAlpha);
    }
}
