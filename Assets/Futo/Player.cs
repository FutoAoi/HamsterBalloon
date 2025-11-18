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
    [SerializeField] private int _bulletLevel = 0;

    private int _nextBallonNumber = 0;
    private int _currentHp;
    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;
    private bool _isHit = false;
    private Color _originalColor;
    private bool _isStan = false;

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
        if (Input.GetMouseButtonDown(0) && !_isHit)
        {
            _rb.AddForce(_junpPower);
            Attack();
        }
    }
    public void Attack()
    {
        if (_isStan) return;
        SoundManager.Instance.PlaySE("Onoma-Pop04-2(Mid-Dry)");
        BulletControlloer bullet1 = Instantiate(_bullet, transform.position, Quaternion.Euler(0, 0, 0));
        bullet1._bulletSpeed = _bulletSpeed;
        if(_bulletLevel >= 1)
        {
            BulletControlloer bullet2 = Instantiate(_bullet, transform.position + new Vector3(0,0.3f,0), Quaternion.Euler(0, 0, 0));
            bullet2._bulletSpeed = _bulletSpeed;
        }
        if (_bulletLevel >= 2)
        {
            BulletControlloer bullet3 = Instantiate(_bullet, transform.position + new Vector3(0, -0.3f, 0), Quaternion.Euler(0, 0, 0));
            bullet3._bulletSpeed = _bulletSpeed;
        }
    }

    public void Hit(int damage)
    {
        if (_isHit) return;

        SoundManager.Instance.PlaySE("ë≈Çøè„Ç∞â‘âŒ2");
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
        _gameManager.SceneChange(1);
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
        Debug.Log("a");
        if (collision.gameObject.CompareTag("Wall"))
        {
            Hit(1);
        }
        if (collision.gameObject.CompareTag("ClearWall"))
        {
            _gameManager.SceneChange(3);
        }
    }

    public void BulletLevelUp()
    {
        _bulletLevel += 1;
    }

    public void Stan()
    {
        SoundManager.Instance.PlaySE("ÉLÉÉÉìÉZÉã6");
        StartCoroutine(StanTime());
    }

    IEnumerator StanTime()
    {
        _isStan = true;
        _spriteRenderer.color = Color.yellow;
        yield return new WaitForSeconds(1.5f);
        _spriteRenderer.color = _originalColor;
        _isStan = false;
    }

    IEnumerator HitInvincibilityTime()
    {
        _isHit = true;
        _rb.linearVelocity = Vector3.zero;
        _spriteRenderer.color = Color.red;
        _rb.AddForce(-_junpPower);
        yield return new WaitForSeconds(_hitStan);
        _spriteRenderer.color = _originalColor;
        _isHit = false;
    }
}
