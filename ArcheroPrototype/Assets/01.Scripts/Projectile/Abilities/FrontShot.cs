using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Abilities/FrontShot", fileName = "FrontShot")]   
public class FrontShot : Ability
{
    [SerializeField] private int maxLevel = 1;
    [SerializeField] private int count = 1;

    public override void AbilityMerge(AbilityManager manager)
    {
        manager.GetComponent<PlayerAttack>().shotPos = -manager.transform.right * 0.25f;

        for (int i = 0; i < count; i++)
        {
            PoolManager.Instance.UseObj(manager.transform.position + manager.transform.right * 0.25f, manager.transform.rotation);
        }
    }
}
