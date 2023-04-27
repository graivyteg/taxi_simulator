using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Wallet : MonoBehaviour
    {
        public static Wallet Instance;

        public event Action<int, int> OnBalanceChanged; 
        
        public int Balance { get; private set; }
        
        private void Awake()
        {
            if (Instance == null) Instance = this;
            else if (Instance != this) Destroy(gameObject);
        }

        private void Start()
        {
            ChangeBalance(PlayerPrefs.GetInt("Balance", 0));
        }
        
        public void AddMoney(int amount)
        {
            ChangeBalance(amount);
        }

        public bool TryRemoveMoney(int amount)
        {
            if (Balance < amount) return false;
            
            ChangeBalance(-amount);
            return true;
        }

        public bool IsEnoughMoney(int amount)
        {
            return Balance >= amount;
        }

        private void ChangeBalance(int delta)
        {
            Balance += delta;
            PlayerPrefs.SetInt("Balance", Balance);
            OnBalanceChanged?.Invoke(Balance - delta, Balance);
        }
    }
}