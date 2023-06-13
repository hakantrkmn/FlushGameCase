using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableManager : MonoBehaviour
{
    public GemHolder gemHolder;

    private void OnEnable()
    {
        EventManager.GetGemHolder += () => gemHolder;
    }

    private void OnDisable()
    {
        EventManager.GetGemHolder -= () => gemHolder;
    }
}
