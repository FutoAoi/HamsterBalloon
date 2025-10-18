using UnityEngine;

public class BulletControlloer : MonoBehaviour
{
    [SerializeField] public float _bulletSpeed;

    Vector2 _nowPosition;
    Transform _tf;

    private void Start()
    {
        _tf = GetComponent<Transform>();
        _nowPosition = _tf.position;
    }
    private void Update()
    {
        _nowPosition += new Vector2(_bulletSpeed, 0f);
        _tf.position = _nowPosition;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        ICharacter character = collision.gameObject.GetComponent<ICharacter>();
        if (character != null)
        {
            character.Hit(1);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
