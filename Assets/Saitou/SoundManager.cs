using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Audio Sources")]
    public AudioSource bgmSource;
    public AudioSource seSource;

    [Header("Audio Clips")]
    public AudioClip[] bgmClips;
    public AudioClip[] seClips;

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
        AudioClip clip = FindClip(bgmClips, name);
        if (clip == null) return;

        if (bgmSource.clip == clip) return;

        bgmSource.clip = clip;
        bgmSource.Play();
    }

    public void StopBGM()
    {
        bgmSource.Stop();
    }

    public void PlaySE(string name)
    {
        AudioClip clip = FindClip(seClips, name);
        if (clip != null)
        {
            seSource.PlayOneShot(clip);
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
