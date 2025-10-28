using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeManager : MonoBehaviour
{
    [SerializeField] float _fadeSpeed = 1.5f;
    [SerializeField] Image _fadeImage;
    private float _alpha;
    private bool _isFading = false;
    public static FadeManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        if (_fadeImage == null)
            _fadeImage = GetComponentInChildren<Image>();

        _alpha = _fadeImage.color.a;
    }

    public void StartFadeIn()
    {
        if (!_isFading)
            StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        _isFading = true;
        _fadeImage.enabled = true;

        while (_alpha > 0)
        {
            _alpha -= _fadeSpeed * Time.deltaTime;
            _fadeImage.color = new Color(0, 0, 0, _alpha);
            yield return null;
        }

        _alpha = 0;
        _fadeImage.color = new Color(0, 0, 0, 0);
        _fadeImage.enabled = false;
        _isFading = false;
    }

    public void StartFadeOut()
    {
        if (!_isFading)
            StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        _isFading = true;
        _fadeImage.enabled = true;

        while (_alpha < 1)
        {
            _alpha += _fadeSpeed * Time.deltaTime;
            _fadeImage.color = new Color(0, 0, 0, _alpha);
            yield return null;
        }

        _alpha = 1;
        _fadeImage.color = new Color(0, 0, 0, 1);
        _isFading = false;
    }

    public bool IsFading => _isFading;
}
