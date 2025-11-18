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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            SoundManager.Instance.PlaySE("ÉJÅ[É\Éãà⁄ìÆ9");
            Destroy(gameObject);
        }
        if(collision.gameObject.CompareTag("BulletWall"))
        {
            Destroy(gameObject);
        }
    }
}
