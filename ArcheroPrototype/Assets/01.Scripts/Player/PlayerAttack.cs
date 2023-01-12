using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackSpeed = 0.7f;
    [SerializeField] private float coolTime = 0f;

    [SerializeField] private EnemySpawner enemySpawner = null;
    [SerializeField] private GameObject[] enemies = null;

    public GameObject targetEnemy = null;

    private PlayerMove playerMove = null;
    private AbilityManager abilityManager = null;

    public Vector3 shotPos = Vector3.zero;
    void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        abilityManager = GetComponent<AbilityManager>();
        enemies = enemySpawner.cloneEnemies.ToArray();
    }

    void Update()
    {
        if (playerMove.IsMove == false)
        {
            coolTime += Time.deltaTime;
            enemies.OrderBy(x => Vector2.Distance(transform.position, x.transform.position));
            targetEnemy = enemies[0];

            transform.LookAt(new Vector3(targetEnemy.transform.position.x, transform.position.y, targetEnemy.transform.position.z));
            if (coolTime >= attackSpeed)
            {
                Attack();
            }
        }
        else
        {
            coolTime = 0f;
        }

        Debug.DrawRay(transform.position, targetEnemy.transform.position - transform.position);
    }

    public void Attack()
    {
        coolTime = 0f;
        PoolManager.Instance.UseObj(transform.position + shotPos, transform.rotation);
        Debug.Log("SHOT!!!");   
        abilityManager.ApplyAbility();
    }
}
