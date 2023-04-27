using DefaultNamespace;
using UnityEngine;

namespace UI
{
    public class AdMoneyButton : SpecialButton
    {
        [SerializeField] private string _placement = "money";
        [SerializeField] private int _amount = 500;

        protected override void Start()
        {
            base.Start();
            YandexSDK.instance.onRewardedAdReward += OnAdRewarded;
        }

        private void OnDestroy()
        {
            YandexSDK.instance.onRewardedAdReward -= OnAdRewarded;
        }

        protected override void OnClick()
        {
#if UNITY_EDITOR
            Debug.Log("Showing Ad");
            OnAdRewarded(_placement);
#endif
            YandexSDK.instance.ShowRewarded(_placement);
        }

        private void OnAdRewarded(string placement)
        {
            Wallet.Instance.AddMoney(_amount);
        }
    }
}