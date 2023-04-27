using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class GameMusicSource : MonoBehaviour
    {
        private AudioSource _source;

        [SerializeField] private AudioClip _menuMusic;
        [SerializeField] private AudioClip _gameMusic;

        [SerializeField] private AudioClip _gameStartedClip;
        [SerializeField] private AudioClip _gameFinishedClip;
        
        private void Start()
        {
            _source = GetComponent<AudioSource>();

            _source.clip = _menuMusic;
            _source.Play();
            
            GameManager.Instance.OnGameStarted += OnGameStarted;
            GameManager.Instance.OnGameFinished += OnGameFinished;
        }

        private void OnDestroy()
        {
            GameManager.Instance.OnGameStarted -= OnGameStarted;
            GameManager.Instance.OnGameFinished -= OnGameFinished;
        }

        private void OnGameStarted()
        {
            _source.Stop();
            _source.PlayOneShot(_gameStartedClip);
            StartCoroutine(PlayWithDelay(_gameStartedClip.length - 0.1f, _gameMusic));
        }

        private void OnGameFinished()
        {
            _source.Stop();
            _source.PlayOneShot(_gameFinishedClip);
            StartCoroutine(PlayWithDelay(_gameFinishedClip.length - 0.1f, _menuMusic));
        }

        private IEnumerator PlayWithDelay(float delay, AudioClip clip)
        {
            yield return new WaitForSeconds(delay);
            _source.clip = clip;
            _source.Play();
        }
    }
}