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
        EventManager.SoldItemPanelButtonClicked+= SoldItemPanelButtonClicked;
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
        if (soldItemPanel.alpha==0)
        {
            soldItemPanel.blocksRaycasts = true;
            soldItemPanel.alpha=1;
            soldItemPanel.interactable = true;
            playerUI.alpha = 0;
            playerUI.interactable = false;
            joystick.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            soldItemPanel.blocksRaycasts = false;
            soldItemPanel.alpha=0;
            soldItemPanel.interactable = false;
            playerUI.alpha = 1;
            playerUI.interactable = true;
            joystick.transform.parent.gameObject.SetActive(true);

        }
    }

    private void GemSold(int amount,Gem soldGem)
    {
        _moneyAmount += amount;
        moneyText.text = _moneyAmount.ToString();
        EventManager.GetGameData().totalMoneyAmount = _moneyAmount;
        SaveManager.SaveGameData(EventManager.GetGameData());

    }

    private void OnDisable()
    {
        EventManager.SoldItemPanelButtonClicked-= SoldItemPanelButtonClicked;
        EventManager.GemSold -= GemSold;
        EventManager.GetJoystick -= () => joystick;
    }
}
