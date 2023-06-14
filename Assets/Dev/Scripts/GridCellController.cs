using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

public class GridCellController : MonoBehaviour
{
    public Collider gridCollider;
    public GemInfo cellGem;
    private Sequence _grow;
    public Gem currentGem;

    private void OnEnable()
    {
        EventManager.StackGem += GemCollected;
    }

    private void OnDisable()
    {
        EventManager.StackGem -= GemCollected;
    }

    public float GetBound()
    {
        return gridCollider.bounds.size.x;
    }

    public void GrowGem()
    {
        var gem = Instantiate(cellGem.spawnPrefab, Vector3.zero, Quaternion.identity,transform);
        gem.transform.localPosition=Vector3.zero;
        gem.GetComponent<Gem>().info = cellGem;
        gem.transform.localScale = Vector3.zero;
        _grow = DOTween.Sequence();
        _grow.Append(gem.transform.DOScale(1, cellGem.growTime));
        currentGem = gem.GetComponent<Gem>();
    }

    public void GemCollected(Gem gem)
    {
        if (currentGem==gem)
        {
            StopGrow();
            SetSellGem();
        }
      
    }

    public void SetSellGem()
    {
        var gemHolder = EventManager.GetGemHolder();
        cellGem = gemHolder.allGems[Random.Range(0,gemHolder.allGems.Count)];
        GrowGem();
    }

    [Button]
    public void StopGrow()
    {
        _grow.Kill();
    }
}
