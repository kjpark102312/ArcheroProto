using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AbilityManager : MonoBehaviour
{
    [SerializeField] private Dictionary<string, Ability> abilities = new Dictionary<string, Ability>();

    public List<Ability> abilityList = new List<Ability>();

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void ApplyAbility(GameObject _projectile)
    {
        if (abilityList.Count > 0)
        {
            for (int i = 0; i < abilityList.Count; i++)
            {
                _projectile.AddComponent<Rigidbody>();
            }
        }
    }

    public void SelectAbility()
    {
        string _abilityName = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;
    }
}
