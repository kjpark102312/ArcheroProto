using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenSelectUI : MonoBehaviour
{

    [SerializeField] private Button openSelectUI = null;

    [SerializeField] private GameObject selectPanel = null;

    private void Start()
    {
        openSelectUI.onClick.AddListener(() =>
        {
            selectPanel.SetActive(true);
        });
    }
}
