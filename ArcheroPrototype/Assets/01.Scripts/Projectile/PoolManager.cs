using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    private static PoolManager instance = null;
    public static PoolManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PoolManager>();
                if (instance == null)
                {
                    GameObject obj = Instantiate(new GameObject());
                    instance = obj.AddComponent<PoolManager>();
                }
            }
            return instance;
        }
    }



    [SerializeField] private GameObject poolObj = null;
    [SerializeField] private List<GameObject> poolLists = new List<GameObject>();

    private int index = 0;



    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }

        GameObject _obj = Instantiate(poolObj);

        //_obj

        _obj.SetActive(false);
        poolLists.Add(_obj);

        for (int i = 0; i < 10; i++)
        {
            Instantiate(_obj);

            _obj.SetActive(false);
            poolLists.Add(_obj);
        }

        instance = this;
    }

    public void UseObj(Vector3 pos,Quaternion rot)
    {
        if (index > poolLists.Count)
            index = 0;
        if (poolLists[index].activeSelf)
        {
            UseObj(pos, rot);
            index++;
            return;
        }

        poolLists[index].transform.position = pos;
        poolLists[index].transform.rotation = rot 
  ;
        poolLists[index].SetActive(true);
        index++;
    }


}
