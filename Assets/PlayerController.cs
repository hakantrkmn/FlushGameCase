using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform stackStartPoint;


    public List<Gem> stack;
    public Transform stackPoint;
    private void OnEnable()
    {
        EventManager.StackGem += StackGem;
    }

    private void OnDisable()
    {
        EventManager.StackGem -= StackGem;
    }

    private void StackGem(Gem gem)
    {
        gem.transform.parent = stackStartPoint;
        gem.transform.position = stackPoint.position;
        stackPoint.position += new Vector3(0, gem.modelCollider.bounds.size.y, 0);
        stack.Add(gem);
    }
}
