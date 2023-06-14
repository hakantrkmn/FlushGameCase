using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class EventManager
{
    public static Func<FloatingJoystick> GetJoystick;
    public static Func<GameData> GetGameData;

    public static Func<GemHolder> GetGemHolder;
    public static Action<Gem> StackGem;
    public static Action<Transform> SellGem;
    public static Action<int,Gem> GemSold;
    public static Action SoldItemPanelButtonClicked;

}
