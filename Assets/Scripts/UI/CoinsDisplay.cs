using UnityEngine;
using TMPro;

public class CoinsDisplay : MonoBehaviour
{
    private TextMeshProUGUI coinsText;

    private void Awake()
    {
        coinsText = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        IlyaMurometz.Instance.OnCoinsChanged += UpdateCoinsText;
        UpdateCoinsText(IlyaMurometz.Instance.Coins);
    }

    private void OnDisable()
    {
        IlyaMurometz.Instance.OnCoinsChanged -= UpdateCoinsText;
    }

    private void UpdateCoinsText(int newCoins)
    {
        coinsText.text = $"Coins: {newCoins}";
    }
}