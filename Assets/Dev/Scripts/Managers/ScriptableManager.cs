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

    private void Start()
    {
        SaveManager.LoadGameData(gameData);
        SaveManager.LoadGameData(gemHolder);
    }

    private void GemSold(int arg1, Gem soldGem)
    {
        foreach (var gemInfo in gemHolder.allGems)
        {
            if (gemInfo.spawnPrefab==soldGem.info.spawnPrefab)
            {
                gemInfo.soldAmount++;
                SaveManager.SaveGameData(gemHolder);
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
