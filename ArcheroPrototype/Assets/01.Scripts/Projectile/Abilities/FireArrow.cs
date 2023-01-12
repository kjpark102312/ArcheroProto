using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Abilities/FireArrow", fileName = "FireArrow")]
public class FireArrow : WeaponAbility
{
    public float damage = 0.4f;
    public float tick = 0.25f;
    public float duration = 0.75f;

    public override void HitAbility(Enemy _enemy)
    {
        _enemy.damage = damage;
        _enemy.tick = tick;
        _enemy.duration = duration;
    }
}
