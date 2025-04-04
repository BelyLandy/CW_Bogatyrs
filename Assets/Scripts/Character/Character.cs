using System;
using UnityEngine;
using System.Collections.Generic;

// Базовый класс Character
public class Character : MonoBehaviour
{
    private int _hp;
    private int _coins;
    
    public int MaxHP { get; protected set; } = 50;

    public int HP
    {
        get => _hp;
        private set
        {
            if (_hp != value)
            {
                _hp = value;
                OnHealthChanged?.Invoke(_hp);
            }
        }
    }
    
    public int Coins
    {
        get => _coins;
        private set
        {
            if (_coins != value)
            {
                _coins = value;
                OnCoinsChanged?.Invoke(_coins);
            }
        }
    }
    
    public Inventory Inventory { get; private set; } = new Inventory();

    public event Action<int> OnHealthChanged;
    public event Action<int> OnCoinsChanged;
    
    protected virtual void Awake()
    {
        _hp = MaxHP;
        _coins = 0;
    }

    public void TakeDamage(int damage) => _hp = Mathf.Max(_hp - damage, 0);

    public void Heal(int amount) => _hp = Mathf.Min(_hp + amount, MaxHP);

    public void AddCoins(int amount) => _coins += Mathf.Max(amount, 0);

    public bool SpendCoins(int amount)
    {
        if (amount > 0 && _coins >= amount)
        {
            _coins -= amount;
            return true;
        }
        return false;
    }
}