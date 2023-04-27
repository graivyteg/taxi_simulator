using DefaultNamespace;
using UnityEngine;

namespace UI
{
    public class WalletText : InjectableText
    {
        protected override void Start()
        {
            base.Start();
            UpdateText();
            Wallet.Instance.OnBalanceChanged += UpdateBalance;
        }

        protected override string GetValue() => Wallet.Instance.Balance.ToString();

        private void OnDestroy()
        {
            Wallet.Instance.OnBalanceChanged -= UpdateBalance;
        }

        private void UpdateBalance(int oldBalance, int newBalance)
        {
            UpdateText();
        }
    }
}