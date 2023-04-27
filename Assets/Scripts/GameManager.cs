using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [SerializeField] private float _respawnHoldTime;

    public bool IsRespawning;
    private float _respawnTimer;

    public event Action OnGameStarted;
    public event Action OnGameFinished;

    public bool IsPlaying = false;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
        
    }


    private void Update()
    {
        if (IsRespawning)
        {
            _respawnTimer += Time.deltaTime;
            if (_respawnTimer >= _respawnHoldTime)
            {
                RespawnPlayer();
            }
        }
        else
        {
            _respawnTimer = 0;
        }
    }

    public void SetDevice(string deviceName)
    {
        PlayerPrefs.SetString("Device", deviceName);
    }

    public void StartGame()
    {
        RespawnPlayer();
        IsPlaying = true;
        OnGameStarted?.Invoke();
    }

    public void FinishGame()
    {
        IsPlaying = false;
        OnGameFinished?.Invoke();
    }

    public void RespawnPlayer()
    {
        _respawnTimer = 0;
        Player.Instance.Respawn();
    }
    
    public float GetRespawnTimeNormalized() => _respawnTimer / _respawnHoldTime;
}
