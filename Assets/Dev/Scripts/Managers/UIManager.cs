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
    public CanvasGroup playerUI;
    
    private void OnEnable()
    {
        EventManager.SoldItemPanelButtonClicked += SoldItemPanelButtonClicked;
        EventManager.GemSold += GemSold;
        EventManager.GetJoystick += () => joystick;
    }

    private void Start()
    {
        _moneyAmount = EventManager.GetGameData().totalMoneyAmount;
        moneyText.text = _moneyAmount.ToString();
    }

    private void SoldItemPanelButtonClicked()
    {
        if (soldItemPanel.alpha == 0)
        {
            ChangeCanvasGroup(soldItemPanel, true);
            ChangeCanvasGroup(playerUI, false);
            joystick.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            ChangeCanvasGroup(soldItemPanel, false);
            ChangeCanvasGroup(playerUI, true);
            joystick.transform.parent.gameObject.SetActive(true);
        }
    }

    void ChangeCanvasGroup(CanvasGroup panel, bool isActive)
    {
        panel.blocksRaycasts = isActive;
        panel.alpha = isActive ? 1 : 0;
        panel.interactable = isActive;
    }

    private void GemSold(int amount, Gem soldGem)
    {
        _moneyAmount += amount;
        moneyText.text = _moneyAmount.ToString();
        EventManager.GetGameData().totalMoneyAmount = _moneyAmount;
        SaveManager.SaveGameData(EventManager.GetGameData());
    }

    private void OnDisable()
    {
        EventManager.SoldItemPanelButtonClicked -= SoldItemPanelButtonClicked;
        EventManager.GemSold -= GemSold;
        EventManager.GetJoystick -= () => joystick;
    }
}