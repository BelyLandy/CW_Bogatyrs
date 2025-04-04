using System;
using UnityEngine;
using TMPro;

public class RageDisplay : MonoBehaviour
{
    private TextMeshProUGUI rageText;

    private void Awake()
    {
        rageText = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        IlyaMurometz.Instance.OnRageChanged += UpdateRageText;
        UpdateRageText(IlyaMurometz.Instance.Rage);
    }

    private void OnDisable()
    {
        IlyaMurometz.Instance.OnRageChanged -= UpdateRageText;
    }

    private void UpdateRageText(int newRage)
    {
        rageText.text = $"Rage: {newRage}";
    }
}