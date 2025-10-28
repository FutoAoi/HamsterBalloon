using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    
    [SerializeField] FadeManager _fadeManager;

    public void SceneChange(int sceneIndex)
    {
        StartCoroutine(ChangeSceneRoutine(sceneIndex));
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
