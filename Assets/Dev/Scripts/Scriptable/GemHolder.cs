using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu]
public class GemHolder : ScriptableObject
{
    public List<GemInfo> allGems;

    [Button]
    public void Save()
    {
        SaveManager.SaveGameData(this);
    }

    [Button]
    public void ResetSoldAmount()
    {
        foreach (var gem in allGems)
        {
            gem.soldAmount = 0;
        }
        Save();
    }
}
