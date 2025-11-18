using UnityEngine;

public class Body : MonoBehaviour
{
    [SerializeField] Player _player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            _player.Stan();
            Destroy(collision.gameObject);
        }
    }
}
