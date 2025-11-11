using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour, ICharacter
{
    [SerializeField] private int _MaxHp;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _attackSpan;
    [SerializeField] private float _hitStan;
    [SerializeField] private BulletControlloer _bullet;
    [SerializeField] private Vector2 _junpPower;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private GameObject[] _balloons;
    [SerializeField] private GameManager _gameManager;

    private int _nextBallonNumber = 0;
    private int _currentHp;
    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;
    private bool _isHit = false;
    private Color _originalColor;

    public int Hp => _currentHp;
    public float MoveSpeed => _moveSpeed;
    public float AttackSpan => _attackSpan;
    public BulletControlloer Bullet => _bullet;

    void Start()
    {
        Application.targetFrameRate = 60;
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _originalColor = _spriteRenderer.color;
        _gameManager = FindAnyObjectByType<GameManager>();
        _MaxHp = _balloons.Length;
        _currentHp = _MaxHp;
    }
    private void Update()
    {
        Move();
    }

    public void Move()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_isHit)
        {
            _rb.AddForce(_junpPower);
            Attack();
        }
    }
    public void Attack()
    {
        BulletControlloer bullet = Instantiate(_bullet,transform.position,Quaternion.Euler(0, 0, 0));
        bullet._bulletSpeed = _bulletSpeed;
    }

    public void Hit(int damage)
    {
        if (_isHit) return;

        StartCoroutine(HitInvincibilityTime());

        _balloons[_nextBallonNumber].SetActive(false);
        _nextBallonNumber++;

        _currentHp -= damage;
        if(_currentHp <= 0)
        {
            Die();
            _currentHp = 0;
        }
    }

    public void Die()
    {
        _gameManager.SceneChange(2);
    }

    public void Heal(int heal = 1)
    {
        Debug.Log("Heal");
        if(_currentHp < _MaxHp)
        {
            _nextBallonNumber--;
            _balloons[_nextBallonNumber].SetActive(true);

            _currentHp += heal;
        }
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
        _rb.linearVelocity = Vector3.zero;
        _spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(_hitStan);
        _spriteRenderer.color = _originalColor;
        _isHit = false;
    }
}
