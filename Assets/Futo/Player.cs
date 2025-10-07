using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, ICharacter
{
    [SerializeField] private int _hp;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _attackSpan;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Vector2 _junpPower;

    private Rigidbody2D _rb;

    public int Hp => _hp;
    public float MoveSpeed => _moveSpeed;
    public float AttackSpan => _attackSpan;
    public GameObject Bullet => _bullet;

    void Start()
    {
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
            //Attack();
        }
    }
    public void Attack()
    {
        Instantiate(_bullet, this.transform.right,Quaternion.identity);
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
