using System;
using UnityEngine;
using System.Collections;

public class CanvasGroupFader : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public Canvas canvas;
    public float fadeDuration = 1f;

    private Coroutine _fadeCoroutine;
    
    public void FadeIn()
    {
        if (_fadeCoroutine != null)
        {
            StopCoroutine(_fadeCoroutine);
        }

        canvas.enabled = true;
        _fadeCoroutine = StartCoroutine(FadeCanvasGroup(0f, 1f));
    }
    
    public void FadeOut()
    {
        if (_fadeCoroutine != null)
        {
            StopCoroutine(_fadeCoroutine);
        }
        _fadeCoroutine = StartCoroutine(FadeCanvasGroup(1f, 0f, () => canvas.enabled = false));
    }

    public bool GetCurrentState()
    {
        return canvas.enabled;
    }
    
    private IEnumerator FadeCanvasGroup(float startAlpha, float endAlpha, Action fadeComplete = null)
    {
        float elapsedTime = 0f;
        
        canvasGroup.alpha = startAlpha;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;

            // Плавное изменение alpha от startAlpha к endAlpha
            canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);

            yield return null;
        }
        
        canvasGroup.alpha = endAlpha;
        
        _fadeCoroutine = null;
        
        fadeComplete?.Invoke();
    }
}