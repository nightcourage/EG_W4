using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinsManager : MonoBehaviour
{
    [SerializeField] private GameObject _coinPref;
    
    [Range(5, 50)]
    [SerializeField] private int coinsAmount;
    [SerializeField] private Ground _ground;

    private List<Coin> _coinsList = new List<Coin>();

    private void Awake()
    {
        GenerateCoins();
    }

    private void Start()
    {
        DistributeCoins(_ground.GroundX, _ground.GroundZ);
    }

    private void GenerateCoins()
    {
        for (int i = 0; i < coinsAmount; i++)
        {
            GameObject newCoin = Instantiate(_coinPref, transform);
            _coinsList.Add(newCoin.GetComponent<Coin>());
        }
    }

    private void DistributeCoins(float width, float length)
    {
        float yPosition = 1f;
        int positionOffset = 5;
        
        foreach (var coin in _coinsList)
        {
            coin.transform.position = new Vector3(Random.Range(2,width - positionOffset), yPosition, Random.Range(2, length - positionOffset));
            coin.transform.rotation = Quaternion.identity;
        }
    }

    public void CollectCoins(Coin coin)
    {
        _coinsList.Remove(coin);
        Destroy(coin.gameObject);
    }

    public int GetLeftCoins()
    {
        return _coinsList.Count;
    }
    
    public Coin FindClosestCoin(Transform pointer)
    {
        float minDistance = Mathf.Infinity;
        Coin coin = null;
        
        for (int i = 0; i < _coinsList.Count; i++)
        {
            float distanceToCoin = Vector3.Distance(pointer.position, _coinsList[i].transform.position);
            if (distanceToCoin < minDistance)
            {
                coin = _coinsList[i];
                minDistance = distanceToCoin;
                Debug.Log(coin.GetHashCode());
            }
        }
        return coin;
    }
}
