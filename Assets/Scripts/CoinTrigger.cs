using System;
using UnityEngine;

public class CoinTrigger : MonoBehaviour
{
    private CoinsManager _coinsManager;
    private GameManager _gameManager;

    private void Start()
    {
        _coinsManager = FindObjectOfType<CoinsManager>();
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerMove player = other.GetComponent<PlayerMove>();
        if (player)
        {
            _coinsManager.CollectCoins(gameObject.GetComponent<Coin>());
            _gameManager.UpdateTextCoinsLeft();
        }
    }
}
