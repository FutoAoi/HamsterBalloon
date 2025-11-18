using UnityEngine;

public class Credit : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    private bool _active = false;

    public void Active()
    {
        _active = !_active;
        _panel.SetActive(_active);
    }
}
