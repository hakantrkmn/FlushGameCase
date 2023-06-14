using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Unity.Mathematics;
using UnityEngine;

public class SoldItemPanelController : MonoBehaviour
{
    public Transform content;
    public SoldItemUI soldItemPrefab;
    public List<SoldItemUI> soldItemlist;

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
                    soldItemlist.Add(item.GetComponent<SoldItemUI>());
                }

               
            }
        }
    }

    public bool CheckIfItemAlreadySpawned(GemInfo gemInfo)
    {
        foreach (var soldItem in soldItemlist)
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