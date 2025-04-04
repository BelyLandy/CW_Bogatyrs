using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    private TextMeshProUGUI healthText;

    private void Awake()
    {
        healthText = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        IlyaMurometz.Instance.OnHealthChanged += UpdateHealthText;
        UpdateHealthText(IlyaMurometz.Instance.HP);
    }

    private void OnDisable()
    {
        IlyaMurometz.Instance.OnHealthChanged -= UpdateHealthText;
    }

    private void UpdateHealthText(int newHP)
    {
        healthText.text = $"HP: {newHP}";
    }
}