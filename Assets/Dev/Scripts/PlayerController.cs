using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform stackStartPoint;
    public List<Gem> stack;
    public Transform stackPoint;
    public GameObject moneyUI;

    private void OnEnable()
    {
        EventManager.StackGem += StackGem;
        EventManager.SellGem += SellGem;
    }

    private void OnDisable()
    {
        EventManager.SellGem -= SellGem;
        EventManager.StackGem -= StackGem;
    }


    private void SellGem(Transform sellPoint)
    {
        if (stack.Count > 0)
        {
            var sellGem = stack.Last();
            var gainedMoney = sellGem.info.price + (sellGem.transform.localScale.x * 100);
            stack.Remove(sellGem);
            stackPoint.position -= new Vector3(0, sellGem.modelCollider.bounds.size.y, 0);
            EventManager.GemSold((int)gainedMoney, sellGem);
            sellGem.transform.DOJump(sellPoint.position, 1, 1, .5f).OnComplete(() => { Destroy(sellGem.gameObject); });
            SpawnMoneyUI((int)gainedMoney);
        }
    }

    void SpawnMoneyUI(int gainedMoney)
    {
        var tempUI = Instantiate(moneyUI, transform.position + Vector3.up * 5, quaternion.identity);
        tempUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "$" + (int)gainedMoney;
        tempUI.transform.DOShakeScale(.5f).OnComplete((() => { Destroy(tempUI.gameObject); }));
    }


    private void StackGem(Gem gem)
    {
        gem.transform.parent = stackStartPoint;
        gem.transform.DOLocalJump(new Vector3(0, stackPoint.localPosition.y, 0), 2, 1, .5f);
        stackPoint.position += new Vector3(0, gem.modelCollider.bounds.size.y, 0);
        stack.Add(gem);
    }
}