using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, ICharacter
{
    [SerializeField] private int _hp;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _attackSpan;
    [SerializeField] private BulletControlloer _bullet;
    [SerializeField] private Vector2 _junpPower;
    [SerializeField] private float _bulletSpeed;

    private Rigidbody2D _rb;

    public int Hp => _hp;
    public float MoveSpeed => _moveSpeed;
    public float AttackSpan => _attackSpan;
    public BulletControlloer Bullet => _bullet;

    void Start()
    {
        Application.targetFrameRate = 60;
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Move();
    }

    public void Move()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(_junpPower);
            Attack();
        }
    }
    public void Attack()
    {
        BulletControlloer bullet = Instantiate(_bullet,transform.position,Quaternion.Euler(0, 0, -90));
        bullet._bulletSpeed = _bulletSpeed;
    }

    public void Hit(int damage)
    {
        _hp -= damage;
        if(_hp < 0)
        {
            Die();
        }
    }
    public void Die()
    {
        SceneManager.LoadScene(0);
    }
}
