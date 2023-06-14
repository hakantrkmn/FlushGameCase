using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCollectable : MonoBehaviour
{
    public GemInfo info;
    public Collider modelCollider;
    

    public virtual void CollectableSold(Vector3 movePoint) { }
    public virtual void CollectableStacked(Vector3 movePoint) { }


}
