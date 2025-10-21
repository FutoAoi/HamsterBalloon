using UnityEngine;

public class Enemy : MonoBehaviour, ICharacter
{
    [SerializeField] private int _hp;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _attackSpan;
    [SerializeField] private BulletControlloer _bulletPrehab;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] GameObject _b;

    float _timer;
    Vector2 _nowPsition;
    Transform _tf;

    public int Hp => _hp;
    public float MoveSpeed => _moveSpeed;
    public float AttackSpan => _attackSpan;
    public BulletControlloer Bullet => _bulletPrehab;

    void Start()
    {
        _tf = GetComponent<Transform>();
        _nowPsition = _tf.position;
    }
    void Update()
    {
        Move();
        Attack();
    }

    public void Attack()
    {
        _timer += Time.deltaTime;
        if(_timer > _attackSpan)
        {
            BulletControlloer bullet = Instantiate(_bulletPrehab, _b.transform.position, Quaternion.Euler(0, 0, 90f));
            bullet._bulletSpeed = _bulletSpeed;
            _timer = 0;
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void Hit(int damage)
    {
        _hp -= damage;
        if(_hp < 0)
        {
            _hp = 0;
            Die();
        }
    }

    public void Move()
    {
        _nowPsition += new Vector2(_moveSpeed, 0f);
        _tf.position = _nowPsition;
    }

}
