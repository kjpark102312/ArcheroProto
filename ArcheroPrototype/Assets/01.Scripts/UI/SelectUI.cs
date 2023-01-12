using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SelectUI : MonoBehaviour
{
    [SerializeField] private Button firstAbilityButton = null;
    [SerializeField] private Button secondAbilityButton = null;
    [SerializeField] private Button thirdAbilityButton = null;

    [SerializeField] private AbilityManager abilityManager = null;
    [SerializeField] private EnemySpawner enemySpawner = null;
    void Start()
    {
        firstAbilityButton.onClick.AddListener(() =>
        {
            transform.DOScale(0,0);
            firstAbilityButton.gameObject.SetActive(false);
            abilityManager.SelectAbility();

            enemySpawner.SpawnEnemy();
        });

        secondAbilityButton.onClick.AddListener(() =>
        {
            transform.DOScale(0, 0);
            secondAbilityButton.gameObject.SetActive(false);
            abilityManager.SelectAbility();

            enemySpawner.SpawnEnemy();
        });

        thirdAbilityButton.onClick.AddListener(() =>
        {
            transform.DOScale(0, 0);
            thirdAbilityButton.gameObject.SetActive(false);
            for (int i = 0; i < PoolManager.Instance.PoolList.Count; i++)
            {
                PoolManager.Instance.PoolList[i].GetComponent<WeaponAbilityManager>().SelectAbility();
            }

            enemySpawner.SpawnEnemy();
        });
    }


    public void ShowPanel()
    {
        transform.DOScale(1, 0.7f);
    }
}
