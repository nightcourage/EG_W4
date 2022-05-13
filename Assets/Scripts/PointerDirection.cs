using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerDirection : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private CoinsManager _coinsManager;
    [SerializeField] private Vector3 yOffset;

    [SerializeField] private Coin _closestCoin;

    private void Update()
    {
        SetPosition();
        _closestCoin = _coinsManager.FindClosestCoin(_player);
        SetDirection(_closestCoin);
    }

    private void SetPosition()
    {
        transform.position = _player.position + yOffset;
    }

    private void SetDirection(Coin coin)
    {
        if (coin != null)
        {
            Vector3 direction = _player.position - coin.transform.position;

            Vector3 directionXZ = new Vector3(direction.x, direction.y, direction.z).normalized;
            Debug.DrawLine(transform.position, _closestCoin.transform.position, Color.blue);

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(-directionXZ), Time.deltaTime);
        }
    }
}
