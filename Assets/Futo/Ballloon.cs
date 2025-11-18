using UnityEngine;

public class Ballloon : MonoBehaviour
{
    [SerializeField] ICharacter _player;
    private void Start()
    {
        _player = GetComponentInParent<ICharacter>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            _player.Hit(1);
            Destroy(collision.gameObject);
        }
    }
}
