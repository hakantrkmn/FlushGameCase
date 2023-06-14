using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Gem : BaseCollectable
{
    public override void CollectableSold(Vector3 movePoint)
    {
        transform.DOJump(movePoint, 1, 1, .5f).OnComplete(() => { Destroy(gameObject); });
    }

    public override void CollectableStacked(Vector3 movePoint)
    {
        transform.DOLocalJump(movePoint, 2, 1, .5f);
    }
    
    
}