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
    public List<GameObject> PoolList { get { return poolLists; } private set { } }
    private List<GameObject> poolLists = new List<GameObject>();

    [SerializeField] private int index = 0;



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

        for (int i = 0; i < 20; i++)
        {
            GameObject _objClone = Instantiate(_obj);

            _objClone.SetActive(false);
            poolLists.Add(_objClone);
        }

        instance = this;
    }

    public void UseObj(Vector3 _pos,Quaternion _rot)
    {
        if (index >= poolLists.Count)
            index = 0;
        if (poolLists[index].activeSelf)
        {
            index++;
            UseObj(_pos, _rot);

            Debug.Log("¾Æ¾Æ");
            return;
        }

        poolLists[index].transform.position = _pos;
        poolLists[index].transform.rotation = _rot;
        poolLists[index].SetActive(true);
       
        index++;
    }


}
