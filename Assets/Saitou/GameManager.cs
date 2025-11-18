using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public enum nowScene
{
    None,
    InGame,
    Title,
    GameClear,
    GameOver
}
public class GameManager : MonoBehaviour
{
    
    [SerializeField] FadeManager _fadeManager;
    [SerializeField] nowScene _scene;

    public void Start()
    {
        Application.targetFrameRate = 60;
        _fadeManager = FindAnyObjectByType<FadeManager>();
        switch (_scene)
        {
            case nowScene.None:
                break;
            case nowScene.InGame:
                SoundManager.Instance.StopBGM();
                SoundManager.Instance.PlayBGM("空を駆ける魔法の箒");
                break;
            case nowScene.Title:
                SoundManager.Instance.StopBGM();
                SoundManager.Instance.PlayBGM("楽しいハムスターのダンス");
                break;
            case nowScene.GameClear:
                SoundManager.Instance.StopBGM();
                SoundManager.Instance.PlayBGM("勝利のテーマ");
                break;
            case nowScene.GameOver:
                SoundManager.Instance.StopBGM();
                SoundManager.Instance.PlayBGM("suteneko ha amenonaka 1");
                break;
            default:
                break;
        }
    }
    public void SceneChange(int sceneIndex)
    {
        if (_fadeManager == null)
        {
            _fadeManager = FindAnyObjectByType<FadeManager>();
        }
        StartCoroutine(ChangeSceneRoutine(sceneIndex));
    }

    public void ButtonSe()
    {
        SoundManager.Instance.PlaySE("決定ボタンを押す12");
    }

    public void EndGame()
    {
#if UNITY_EDITOR
      
        UnityEditor.EditorApplication.isPlaying = false;
#else
      
        Application.Quit();
#endif
    }

    IEnumerator ChangeSceneRoutine(int sceneIndex)
    {
        _fadeManager.StartFadeOut();
        yield return new WaitUntil(() => !_fadeManager.IsFading);

        SceneManager.LoadScene(sceneIndex);

        _fadeManager.StartFadeIn();
    }
}
