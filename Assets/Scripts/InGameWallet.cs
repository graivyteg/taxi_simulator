using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Random = UnityEngine.Random;

public class InGameWallet : MonoBehaviour
{
    public static InGameWallet Instance;

    public event Action<int, int> OnBalanceChanged;
    
    [SerializeField] private int _minTaskAward;
    [SerializeField] private int _maxTaskAward;

    private int _balance;
    
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
    }

    private void Start()
    {
        _balance = 0;
        
        TaskController.Instance.OnTaskFinished += GetTaskAward;
        GameManager.Instance.OnGameStarted += OnGameStarted;
        GameManager.Instance.OnGameFinished += OnGameFinished;
    }

    private void OnDestroy()
    {
        TaskController.Instance.OnTaskFinished -= GetTaskAward;
        GameManager.Instance.OnGameStarted -= OnGameStarted;
        GameManager.Instance.OnGameFinished -= OnGameFinished;
    }
    
    
    private void OnGameStarted()
    {
        TryRemoveBalance(_balance);
    }

    private void OnGameFinished()
    {
        Wallet.Instance.AddMoney(_balance);
    }
    
    private void GetTaskAward()
    {
        AddBalance(Random.Range(_minTaskAward, _maxTaskAward + 1));
    }
    
    public int GetBalance() => _balance;

    public void AddBalance(int amount)
    {
        _balance += amount;
        OnBalanceChanged?.Invoke(_balance - amount, _balance);
    }

    public bool TryRemoveBalance(int amount)
    {
        if (_balance < amount) return false;
        
        _balance -= amount;
        OnBalanceChanged?.Invoke(_balance + amount, _balance);
        return true;
    }
}