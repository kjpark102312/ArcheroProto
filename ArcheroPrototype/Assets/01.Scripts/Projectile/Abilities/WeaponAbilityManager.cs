using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class WeaponAbilityManager : MonoBehaviour
{
    [System.Serializable]
    public class SerializeDicEntity : CustomDic.SerializableDictionary<string, WeaponAbility> { }
    public SerializeDicEntity abilityDic;


    public List<WeaponAbility> abilityList = new List<WeaponAbility>();

    public void ApplyAbility(Enemy _enemy)
    {
        if (abilityList.Count > 0)
        {
            for (int i = 0; i < abilityList.Count; i++)
            {
                abilityList[i].HitAbility(_enemy);
            }
        }
    }

    public void SelectAbility()
    {
        string _abilityName = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TextMeshProUGUI>().text;

        abilityList.Add(abilityDic[_abilityName]);
    }
}
