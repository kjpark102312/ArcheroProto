using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Abilities/SideShot", fileName = "SideShot")]

public class SideShot : Ability
{

    [SerializeField] private int count = 1;

    public override void AbilityMerge(AbilityManager manager)
    {
        Quaternion quaternion = Quaternion.Euler(new Vector3(0, manager.transform.localEulerAngles.y + 90, 0));
        Quaternion quaternion2 = Quaternion.Euler(new Vector3(0, manager.transform.localEulerAngles.y + 270, 0));

        Debug.Log(manager.transform.rotation.y);
        Debug.Log(manager.transform.localEulerAngles.y + 90);
        Debug.Log(manager.transform.rotation.y + 270);

        PoolManager.Instance.UseObj(manager.transform.position, quaternion);
        PoolManager.Instance.UseObj(manager.transform.position, quaternion2);
    }
}
