using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource _bgmSource;
    [SerializeField] private AudioSource _seSource;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip[] _bgmClips;
    [SerializeField] private AudioClip[] _seClips;

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
    }

    public void PlayBGM(string name)
    {
        AudioClip clip = FindClip(_bgmClips, name);
        if (clip == null) return;

        if (_bgmSource.clip == clip) return;

        _bgmSource.clip = clip;
        _bgmSource.Play();
    }

    public void StopBGM()
    {
        _bgmSource.Stop();
    }

    public void PlaySE(string name)
    {
        AudioClip clip = FindClip(_seClips, name);
        if (clip != null)
        {
            _seSource.PlayOneShot(clip);
        }
    }

    private AudioClip FindClip(AudioClip[] clips, string name)
    {
        foreach (var clip in clips)
        {
            if (clip != null && clip.name == name)
                return clip;
        }
        return null;
    }
}
