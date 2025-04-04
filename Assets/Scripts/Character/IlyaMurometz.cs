using UnityEngine;
using System;

public class IlyaMurometz : Character
{
    private static IlyaMurometz _instance;
    public static IlyaMurometz Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindFirstObjectByType<IlyaMurometz>();
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject("IlyaMurometzSingleton");
                    _instance = singletonObject.AddComponent<IlyaMurometz>();
                    DontDestroyOnLoad(singletonObject);
                }
            }
            return _instance;
        }
    }

    private int _rage;
    public int MaxRage { get; private set; } = 100;
    public int Rage
    {
        get => _rage;
        private set
        {
            if (_rage != value)
            {
                _rage = value;
                OnRageChanged?.Invoke(_rage);
            }
        }
    }

    public event Action<int> OnRageChanged;

    protected override void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        base.Awake();
        _rage = 0;
    }

    public void AddRage(int amount) => Rage = Mathf.Min(_rage + amount, MaxRage);

    public void SpendRage(int amount) => Rage = Mathf.Max(_rage - amount, 0);
}