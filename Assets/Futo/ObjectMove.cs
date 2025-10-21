using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    [SerializeField] private float _objectSpeed = 1f;
    [SerializeField] private float _destroyX = -20f;

    Transform _tf;

    private void Start()
    {
        _tf = transform;
    }

    private void Update()
    {
        transform.Translate(Vector3.left * _objectSpeed * Time.deltaTime, Space.World);

        if(transform.position.x < _destroyX )
        {
            Destroy(gameObject);
        }
    }
}
