using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject _Prehab;
    [SerializeField] int _spwanX;
    [SerializeField] private float _objectSpeed = 1.5f;

    Transform _tf;

    private void Start()
    {
        _tf = GetComponent<Transform>();
    }

    private void Update()
    {
        _tf.Translate(Vector3.left * _objectSpeed * Time.deltaTime, Space.World);
        if (_tf.position.x < _spwanX)
        {
            Instantiate(_Prehab, _tf.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
