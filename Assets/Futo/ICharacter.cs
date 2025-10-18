using UnityEngine;

public interface ICharacter
{
    int Hp { get; }
    float MoveSpeed { get; }
    float AttackSpan { get; }
    BulletControlloer Bullet { get; }
    void Move();
    void Attack();
    void Hit(int damage);
    void Die();
}
