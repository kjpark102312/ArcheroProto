using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    public List<GameObject> cloneEnemies = new List<GameObject>();

    private int enemyIndex = 0;
    void Start()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            GameObject _obj = Instantiate(enemies[i].gameObject, transform.position, Quaternion.identity);
            cloneEnemies.Add(_obj);

            _obj.SetActive(false);
        }

        cloneEnemies[0].SetActive(true);
    }

    private void Update()
    {
        if (cloneEnemies[enemyIndex].GetComponent<Enemy>().isDead)
        {
            enemyIndex++;

            if (enemyIndex >= enemies.Length)
                return;

            
        }
    }

    public void SpawnEnemy()
    {
        cloneEnemies[enemyIndex].SetActive(true);
    }
}
