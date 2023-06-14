using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableManager : MonoBehaviour
{
    public GemHolder gemHolder;
    public GameData gameData;
    private void OnEnable()
    {
        EventManager.GemSold += GemSold;
        EventManager.GetGemHolder += () => gemHolder;
        EventManager.GetGameData += () => gameData;
    }

    private void GemSold(int arg1, Gem soldGem)
    {
        foreach (var gemInfo in gemHolder.allGems)
        {
            if (gemInfo.spawnPrefab==soldGem.info.spawnPrefab)
            {
                gemInfo.soldAmount++;
                return;
            }
        }
    }

    private void OnDisable()
    {
        EventManager.GemSold -= GemSold;
        EventManager.GetGameData -= () => gameData;
        EventManager.GetGemHolder -= () => gemHolder;
    }
}