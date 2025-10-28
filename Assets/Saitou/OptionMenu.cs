using UnityEngine;

public class OptionMenu : MonoBehaviour
{
    [SerializeField] GameObject _optionPrefab; // �I�v�V����UI��Prefab
    GameObject optionInstance;

    public void OpenOption()
    {
        if (optionInstance == null)
        {
            Canvas canvas = FindFirstObjectByType<Canvas>();
            optionInstance = Instantiate(_optionPrefab, canvas.transform);
        }
    }
}
