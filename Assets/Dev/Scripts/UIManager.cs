using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public FloatingJoystick joystick;
    public TextMeshProUGUI moneyText;
    private int _moneyAmount;
    public CanvasGroup soldItemPanel;
    private void OnEnable()
    {
        EventManager.SoldItemPanelButtonClicked+= SoldItemPanelButtonClicked;
        EventManager.GemSold += GemSold;
        EventManager.GetJoystick += () => joystick;
    }

    private void SoldItemPanelButtonClicked()
    {
        Debug.Log("lekngşkdsfg");
        if (soldItemPanel.alpha==0)
        {
            soldItemPanel.alpha=1;
            soldItemPanel.interactable = true;
        }
        else
        {
            soldItemPanel.alpha=0;
            soldItemPanel.interactable = false;
        }
    }

    private void GemSold(int amount,Gem soldGem)
    {
        _moneyAmount += amount;
        moneyText.text = _moneyAmount.ToString();
        EventManager.GetGameData().totalMoneyAmount = _moneyAmount;
    }

    private void OnDisable()
    {
        EventManager.SoldItemPanelButtonClicked-= SoldItemPanelButtonClicked;
        EventManager.GemSold -= GemSold;
        EventManager.GetJoystick -= () => joystick;
    }
}
