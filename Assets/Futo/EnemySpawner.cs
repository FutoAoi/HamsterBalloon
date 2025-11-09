using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrehab;
    [SerializeField] int _spwanX;
    [SerializeField] private float _objectSpeed = 1.2f;

    Transform _tf;

    private void Start()
    {
        _tf = GetComponent<Transform>();
    }

    private void Update()
    {
        transform.Translate(Vector3.left * _objectSpeed * Time.deltaTime, Space.World);
        if (_tf.position.x < _spwanX)
        {
            Instantiate(_enemyPrehab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
