using UnityEngine;

public class OptionMenu : MonoBehaviour
{
    [SerializeField] GameObject _optionPrefab; // ƒIƒvƒVƒ‡ƒ“UI‚ÌPrefab
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
