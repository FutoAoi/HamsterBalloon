using UnityEngine;

public class OptionMenu : MonoBehaviour
{
    [SerializeField] GameObject optionWindow;

    public void OpenOption()
    {
        optionWindow.SetActive(true); // �\��
    }

    public void Close()
    {
        gameObject.SetActive(false); // ��\���ɖ߂�
    }
}