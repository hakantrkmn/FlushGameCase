using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SoldItemUI : MonoBehaviour
{
    public GemInfo info;

    public TextMeshProUGUI gemTypeText;

    public TextMeshProUGUI collectedAmountText;

    public Image icon;

    public void SetItem()
    {
        gemTypeText.text = "Gem Name : "+info.name;
        collectedAmountText.text = "Collected Count : "+info.soldAmount.ToString();
        icon.sprite = info.icon;
    }
}
