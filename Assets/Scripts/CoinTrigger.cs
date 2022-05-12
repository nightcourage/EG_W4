using UnityEngine;

public class CoinTrigger : MonoBehaviour
{
    [SerializeField] private CoinsManager _coinsManager;
    [SerializeField] private GameManager _gameManager;
    
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
