using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameAdShower : MonoBehaviour
    {
        [SerializeField] private int _gamesPerAd = 3;
        
        private void Start()
        {
            GameManager.Instance.OnGameFinished += OnGameFinished;
        }

        private void OnDestroy()
        {
            GameManager.Instance.OnGameFinished -= OnGameFinished;
        }

        private void OnGameFinished()
        {
            int gameId = PlayerPrefs.GetInt("GameId", 0);
            if (gameId >= _gamesPerAd - 1)
            {
                try
                {
                    PlayerPrefs.SetInt("GameId", 0);
                    Debug.Log("Showing Interstitial");
                    YandexSDK.instance.ShowInterstitial();
                }
                catch
                {
                    
                }
            }
            else
            {
                PlayerPrefs.SetInt("GameId", gameId + 1);
            }
        }
    }
}