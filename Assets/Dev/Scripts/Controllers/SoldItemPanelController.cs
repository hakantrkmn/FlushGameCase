using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SoldItemPanelController : MonoBehaviour
{
    public Transform content;
    public SoldItemUI soldItemPrefab;
    List<SoldItemUI> _soldItemList;

    private void Start()
    {
        _soldItemList = new List<SoldItemUI>();
        SetCellSize();
    }

    void SetCellSize()
    {
        var cellsize = new Vector2(GetComponent<RectTransform>().rect.width,
            GetComponent<RectTransform>().rect.height / 3);
        content.GetComponent<GridLayoutGroup>().cellSize = cellsize;
    }

    private void OnEnable()
    {
        EventManager.SoldItemPanelButtonClicked += SetSoldItemPanel;
    }

    private void OnDisable()
    {
        EventManager.SoldItemPanelButtonClicked -= SetSoldItemPanel;
    }

    [Button]
    public void SetSoldItemPanel()
    {
        var soldItems = EventManager.GetGemHolder();

        foreach (var gemInfo in soldItems.allGems)
        {
            if (gemInfo.soldAmount != 0)
            {
                if (!CheckIfItemAlreadySpawned(gemInfo))
                {
                    var item = Instantiate(soldItemPrefab.gameObject, content);
                    item.GetComponent<SoldItemUI>().info = gemInfo;
                    item.GetComponent<SoldItemUI>().SetItem();
                    _soldItemList.Add(item.GetComponent<SoldItemUI>());
                }

               
            }
        }
    }

    bool CheckIfItemAlreadySpawned(GemInfo gemInfo)
    {
        foreach (var soldItem in _soldItemList)
        {
            if (soldItem.info.spawnPrefab == gemInfo.spawnPrefab)
            {
                soldItem.info.soldAmount = gemInfo.soldAmount;
                soldItem.SetItem();
                return true;
            }
        }

        return false;
    }
}