using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private CoinsManager _coinsManager;

    private void Start()
    {
        UpdateTextCoinsLeft();
    }

    public void UpdateTextCoinsLeft()
    {
        int leftCoins = _coinsManager.GetLeftCoins();
        _text.text = $"Осталось собрать: {leftCoins}";
    }
}
