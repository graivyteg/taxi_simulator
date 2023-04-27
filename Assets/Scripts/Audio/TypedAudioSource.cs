using System;
using UnityEngine;

namespace DefaultNamespace.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class TypedAudioSource : MonoBehaviour
    {
        [SerializeField] private AudioType _type;
        
        [Range(0f, 1f)]
        [SerializeField] private float _defaultValue = 0.7f;
        [SerializeField] private float _multiplier = 1f;

        [SerializeField] private bool _yandexIncluded = true;
        private bool _isAdPlaying = false;

        private AudioSource _source;
        
        private void Start()
        {
            _source = GetComponent<AudioSource>();

            if (_yandexIncluded)
            {
                YandexSDK.instance.onRewardedAdClosed += OnAdClosed;
                YandexSDK.instance.onRewardedAdError += OnAdFailed;
                YandexSDK.instance.onRewardedAdOpened += OnAdOpened;
                YandexSDK.instance.onRewardedAdReward += OnAdRewarded;
            }
        }

        private void Update()
        {
            if (!_isAdPlaying || !_yandexIncluded)
            {
                _source.volume = PlayerPrefs.GetFloat(_type.ToString(), _defaultValue) * _multiplier;
            }
            else
            {
                _source.volume = 0;
            }
        }

        private void OnAdRewarded(string placement)
        {
            _isAdPlaying = false;
        }

        private void OnAdFailed(string placement)
        {
            _isAdPlaying = false;
        }
        
        private void OnAdClosed(int id)
        {
            _isAdPlaying = false;
        }
        
        private void OnAdOpened(int id)
        {
            _isAdPlaying = true;
        }
    }
}