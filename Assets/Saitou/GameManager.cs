using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void SceneChange(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void EndGame()
    {
#if UNITY_EDITOR
      
        UnityEditor.EditorApplication.isPlaying = false;
#else
      
        Application.Quit();
#endif
    }

    public void GameOver()
    {
        SceneManager.LoadScene(2);
    }
}
