using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu]
public class GameData : ScriptableObject
{
   public int totalMoneyAmount;
   [Button]
   public void Save()
   {
      SaveManager.SaveGameData(this);
   }
}
