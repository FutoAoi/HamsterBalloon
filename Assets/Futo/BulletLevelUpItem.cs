
public class BulletLevelUpItem : ItemBase
{
    protected override void Excute()
    {
        _target.GetComponentInParent<Player>().BulletLevelUp();
    }
}
