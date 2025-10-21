using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, ICharacter
{
    [SerializeField] private int _hp;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _attackSpan;
    [SerializeField] private BulletControlloer _bullet;
    [SerializeField] private Vector2 _junpPower;
    [SerializeField] private Vector2 _downPower;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private GameObject[] _balloons;

    private int _nextBallonNumber = 0;
    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;
    private bool _isHit = false;
    private Color _originalColor;

    public int Hp => _hp;
    public float MoveSpeed => _moveSpeed;
    public float AttackSpan => _attackSpan;
    public BulletControlloer Bullet => _bullet;

    void Start()
    {
        Application.targetFrameRate = 60;
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _originalColor = _spriteRenderer.color;
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
        if (_isHit) return;

        StartCoroutine(HitInvincibilityTime());

        _balloons[_nextBallonNumber].SetActive(false);
        _nextBallonNumber++;

        _hp -= damage;
        if(_hp < 0)
        {
            Die();
        }
    }
    public void Die()
    {
        Debug.Log("Ž€");
    
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Hit(1);
        }
    }

    IEnumerator HitInvincibilityTime()
    {
        _isHit = true;
        _rb.AddForce(_downPower);
        _spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(1);
        _spriteRenderer.color = _originalColor;
        _isHit = false;
    }
}
