using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform stackStartPoint;


    public List<Gem> stack;
    public Transform stackPoint;
    private void OnEnable()
    {
        EventManager.StackGem += StackGem;
        EventManager.SellGem += SellGem;
    }

    private void SellGem()
    {
        if (stack.Count>0)
        {
            var sellGem = stack.Last();
            var gainedMoney = sellGem.info.price + (sellGem.transform.localScale.x*100);
            stack.Remove(sellGem);
            stackPoint.position -= new Vector3(0, sellGem.modelCollider.bounds.size.y, 0);
            EventManager.GemSold((int)gainedMoney,sellGem);
            Destroy(sellGem.gameObject);
        }
    }

    private void OnDisable()
    {
        EventManager.SellGem -= SellGem;
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