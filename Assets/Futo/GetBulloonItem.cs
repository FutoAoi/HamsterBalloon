using UnityEngine;

public class GetBulloonItem : ItemBase
{
    protected override void Excute()
    {
        _target.GetComponentInParent<Player>().Heal();
    }
}
