using System;
using DefaultNamespace;
using UnityEngine;

namespace UI
{
    public class SkinButton : SpecialButton
    {
        [SerializeField] private string _skinName;
        [SerializeField] private Skin _skin;
        [SerializeField] private bool _isDefault;

        [Space(20)] 
        [SerializeField] private GameObject _closedImage;
        
        private bool _isOpened = false;
        
        protected override void Start()
        {
            base.Start();

            _isOpened = PlayerPrefs.HasKey(_skinName);
            UpdateInteractable();
            
            if(PlayerPrefs.GetString("Skin", "white") == _skinName)
            {
                _skin.Apply(SkinChanger.Instance);
            }

            YandexSDK.instance.onRewardedAdReward += OnAdRewarded;
        }

        private void OnDestroy()
        {
            YandexSDK.instance.onRewardedAdReward -= OnAdRewarded;
        }

        protected override void OnClick()
        {
            if (_isOpened || _isDefault)
            {
                _skin.Apply(SkinChanger.Instance);
                PlayerPrefs.SetString("Skin", _skinName);
                return;
            }
#if UNITY_EDITOR
            Debug.Log("Showing Ad");
            OnAdRewarded(_skinName);
#endif
            YandexSDK.instance.ShowRewarded(_skinName);
        }

        private void OnAdRewarded(string placement)
        {
            if (placement != _skinName) return;
            
            _isOpened = true;
            PlayerPrefs.SetInt(_skinName, 1);
            UpdateInteractable();
        }

        private void UpdateInteractable()
        {
            _closedImage.SetActive(!_isOpened && !_isDefault);
        }
    }
}