using System;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;

namespace UI
{
    public abstract class UpgradeButton<T> : SpecialButton
    {
        [SerializeField] protected List<Upgrade<T>> Upgrades;
        [SerializeField] protected string UpgradeName;

        [Space(20)] 
        [SerializeField] private PriceText _priceText;
        [SerializeField] private LevelText _levelText;

        protected int CurrentUpgradeId = 0;

        protected override void Start()
        {
            base.Start();
            CurrentUpgradeId = PlayerPrefs.GetInt(UpgradeName, 0);
            UpdateUI();
            
            GameManager.Instance.OnGameStarted += ApplyUpgrade;
            Wallet.Instance.OnBalanceChanged += OnBalanceUpdated;
        }

        protected virtual void OnDestroy()
        {
            GameManager.Instance.OnGameStarted -= ApplyUpgrade;
            Wallet.Instance.OnBalanceChanged -= OnBalanceUpdated;
        }

        protected abstract void ApplyUpgrade();

        protected override void OnClick()
        {
            if (!Wallet.Instance.TryRemoveMoney(Upgrades[CurrentUpgradeId + 1].Price)) return;
            
            CurrentUpgradeId++;
            PlayerPrefs.SetInt(UpgradeName, CurrentUpgradeId);
            UpdateUI();
        }

        private void OnBalanceUpdated(int oldBalance, int newBalance)
        {
            UpdateInteractable();
        }
        
        private void UpdateInteractable()
        {
            if (CurrentUpgradeId == Upgrades.Count - 1)
            {
                Button.interactable = false;
                return;
            }

            Button.interactable = Wallet.Instance.IsEnoughMoney(Upgrades[CurrentUpgradeId + 1].Price);
        }

        private bool IsMaxLevel() => CurrentUpgradeId == Upgrades.Count - 1;

        private void UpdateUI()
        {
            if (IsMaxLevel())
            {
                _levelText.SetMaxLevel();
                _priceText.SetNonePrice();
            }
            else
            {
                _levelText.SetLevel(CurrentUpgradeId + 1);
                _priceText.SetPrice(Upgrades[CurrentUpgradeId + 1].Price);
            }
            
            _levelText.UpdateText();
            _priceText.UpdateText();
            UpdateInteractable();
        }
    }
}