using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _fadeSphere;
    [SerializeField] private float _fadeDuration = 1.0f;

    private Renderer _sphereRenderer;
    private bool _isFading = false;

    private void Start()
    {
        _sphereRenderer = _fadeSphere.GetComponent<Renderer>();
        Color startColor = _sphereRenderer.material.color;
        startColor.a = 0;
        _sphereRenderer.material.color = startColor;

        // Don't destroy the XR Rig during scene load
        DontDestroyOnLoad(_player);
    }

    public void StartSceneChange(string sceneName)
    {
        if (!_isFading)
        {
            StartCoroutine(Transition(sceneName));
        }
    }

    private IEnumerator Transition(string sceneName)
    {
        _isFading = true;

        // Activate fade effect on the sphere
        _fadeSphere.SetActive(true);
        StartCoroutine(FadeSphere(0f, 1f, _fadeDuration));

        // Wait for the fade effect to complete
        yield return new WaitForSeconds(_fadeDuration);

        // Load the new scene asynchronously
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);



        // Wait until the new scene has finished loading
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Deactivate fade effect on the sphere
        StartCoroutine(FadeSphere(1f, 0f, _fadeDuration));

        // Wait for the fade effect to complete
        yield return new WaitForSeconds(_fadeDuration);

        // Disable the fade sphere
        _fadeSphere.SetActive(false);

        _isFading = false;
    }

    private IEnumerator FadeSphere(float startAlpha, float endAlpha, float duration)
    {
        float startTime = Time.time;
        float elapsedTime = 0f;

        Color startColor = _sphereRenderer.material.color;

        while (elapsedTime < duration)
        {
            elapsedTime = Time.time - startTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            float alpha = Mathf.Lerp(startAlpha, endAlpha, t);

            Color newColor = startColor;
            newColor.a = alpha;

            _sphereRenderer.material.color = newColor;

            yield return null;
        }
    }
}