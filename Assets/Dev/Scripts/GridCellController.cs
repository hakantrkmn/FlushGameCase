using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
public class GridCellController : MonoBehaviour
{
    public Collider gridCollider;
    public Gem cellGem;
    public bool canCollect;
    
    public float GetBound()
    {
        return gridCollider.bounds.size.x;
    }

    public void GrowGem()
    {
        var gem = Instantiate(cellGem.spawnPrefab, Vector3.zero, Quaternion.identity,transform);
        gem.transform.localPosition=Vector3.zero;
        gem.transform.localScale = Vector3.zero;
        gem.transform.DOScale(1, 5);
    }
}
