
using System;
using UnityEngine;

[Serializable]
public class GemInfo
{
    public string name;
    public int price;
    public Sprite icon;
    public GameObject spawnPrefab;
    public int soldAmount;
    public float growTime;
}

[Serializable]
public class SoldGem
{
    public string name;
    public int soldAmount;
}