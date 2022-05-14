using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private CoinsManager _coinsManager;
    [SerializeField] private GameObject WinScreen;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Rigidbody targetRigidbody;

    private void Start()
    {
        _restartButton.onClick.AddListener(Restart);
        UpdateTextCoinsLeft();
        WinScreen.SetActive(false);
    }

    private void Update()
    {
        if (_coinsManager.GetLeftCoins() == 0)
        {
            Win();
        }
    }

    public void UpdateTextCoinsLeft()
    {
        int leftCoins = _coinsManager.GetLeftCoins();
        _text.text = $"Осталось собрать: {leftCoins}";
    }

    private void Win()
    {
        WinScreen.SetActive(true);
        _text.enabled = false;
        targetRigidbody.isKinematic = true;
    }

    private void Restart()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex);
    }
}
