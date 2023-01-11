using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    public List<GameObject> cloneEnemies = new List<GameObject>();
    void Start()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            GameObject _obj = Instantiate(enemies[i].gameObject, transform.position, Quaternion.identity);
            cloneEnemies.Add(_obj);
        }
    }
}
