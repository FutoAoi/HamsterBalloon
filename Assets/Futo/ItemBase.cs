using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    [SerializeField] private float _objectSpeed = 1.5f;
    [SerializeField] private float _destroyX = -20f;

    protected GameObject _target;
    private Transform _tf;
    protected abstract void Excute();
    private void Start()
    {
        _tf = GetComponent<Transform>();
    }
    private void Update()
    {
        _tf.Translate(Vector3.left * _objectSpeed * Time.deltaTime, Space.World);
        if(_tf.position.x <=  _destroyX)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            _target = collision.gameObject;
            SoundManager.Instance.PlaySE("Œˆ’èƒ{ƒ^ƒ“‚ð‰Ÿ‚·40");
            Excute();
            Destroy(gameObject);
        }
    }
}
