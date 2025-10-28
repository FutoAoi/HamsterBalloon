using UnityEngine;

public class OptionMenu : MonoBehaviour
{
    [SerializeField] GameObject optionWindow;

    public void OpenOption()
    {
        optionWindow.SetActive(true); // •\Ž¦
    }

    public void Close()
    {
        gameObject.SetActive(false); // ”ñ•\Ž¦‚É–ß‚·
    }
}