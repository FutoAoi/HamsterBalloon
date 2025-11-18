using UnityEngine;

public class FlyEnemy : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    [SerializeField] float _destloyX = -20;
    Transform _tf;

    private void Start()
    {
        _tf = transform;
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        _tf.Translate(Vector3.left * _moveSpeed * Time.deltaTime, Space.World);
        if (_tf.position.x < _destloyX)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        ICharacter character = collision.gameObject.GetComponent<ICharacter>();
        if (character != null)
        {
            if (collision.gameObject.CompareTag("Bulloon"))
            {
                character.Hit(1);
                Destroy(gameObject);
            }
            if (collision.gameObject.CompareTag("Body"))
            {
                collision.gameObject.GetComponent<Player>().Stan();
            }
        }
    }
}
