using UnityEngine;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    [SerializeField] GameObject optionWindow;
    [SerializeField] Slider _bgmSlider;
    [SerializeField] Slider _seSlider;

    private void Start()
    {
        _bgmSlider.value = 1.0f;
        _seSlider.value = 1.0f;

        _bgmSlider.onValueChanged.AddListener(OnBGMVolumeChanged);
        _seSlider.onValueChanged.AddListener(OnSEVolumeChanged);
    }

    public void OpenOption()
    {
        optionWindow.SetActive(true); // •\Ž¦
    }

    public void Close()
    {
        optionWindow.SetActive(false); // ”ñ•\Ž¦‚É–ß‚·
    }

    void OnBGMVolumeChanged(float value)
    {
        if (SoundManager.Instance)
            SoundManager.Instance._bgmSource.volume = value;
    }

    void OnSEVolumeChanged(float value)
    {
        if (SoundManager.Instance)
            SoundManager.Instance._seSource.volume = value;
    }
}