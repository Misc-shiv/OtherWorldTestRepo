using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class CanvasGroupFader : MonoBehaviour
{
    [SerializeField] private float _fadeDelay = 1f;
    [SerializeField, Range(0.1f, 2f)] private float _fadeSpeed = 1f;
    [SerializeField] private float _startingAlpha = 0f;
    [SerializeField] private float _finalAlpha = 1f;

    private CanvasGroup _canvasGroup;

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = _startingAlpha;
        StartCoroutine(Fade(_startingAlpha, _finalAlpha, _fadeDelay));
    }

    private IEnumerator Fade(float startAlpha, float endAlpha, float delay)
    {
        yield return new WaitForSeconds(delay);

        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * _fadeSpeed;
            _canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, t);
            yield return null;
        }
    }
}