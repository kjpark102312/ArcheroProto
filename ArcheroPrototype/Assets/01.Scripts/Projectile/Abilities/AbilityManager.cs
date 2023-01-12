using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
public class AbilityManager : MonoBehaviour
{

    [System.Serializable]
    public class SerializeDicEntity : CustomDic.SerializableDictionary<string, Ability> { }
    public SerializeDicEntity abilityDic;


    public List<Ability> abilityList = new List<Ability>();

    public void ApplyAbility()
    {
        if (abilityList.Count > 0)
        {
            for (int i = 0; i < abilityList.Count; i++)
            {
                abilityList[i].AbilityMerge(this);
            }
        }
    }

    public void SelectAbility()
    {
        string _abilityName = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TextMeshProUGUI>().text;

        abilityList.Add(abilityDic[_abilityName]);
    }
}
