using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class InGameBalanceText : InjectableText
{
    private float _tempBalance;
    
    protected override void Start()
    {
        base.Start();
        UpdateText();

        InGameWallet.Instance.OnBalanceChanged += UpdateBalance;
    }

    protected override string GetValue() => InGameWallet.Instance.GetBalance().ToString();

    private void OnDestroy()
    {
        InGameWallet.Instance.OnBalanceChanged -= UpdateBalance;
    }

    private void UpdateBalance(int oldBalance, int newBalance)
    {
        UpdateText();
    }
}