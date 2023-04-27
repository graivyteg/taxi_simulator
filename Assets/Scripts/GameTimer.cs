using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public static GameTimer Instance;
    
    [SerializeField] private float _gameTime;
    
    [SerializeField] private float _taskBonus = 10;
    
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _additionalTextLifetime;
    
    public event Action OnTimerFinished;

    private string _additionalText = "";
    private bool _isWorking = false;
    
    private float _timeLeft;

    private string MinutesLeft
    {
        get
        {
            int minutes = Mathf.CeilToInt(_timeLeft) / 60;
            return minutes < 10 ? "0" + minutes : minutes.ToString();
        }
    }

    private string SecondsLeft
    {
        get
        {
            int seconds = Mathf.CeilToInt(_timeLeft) % 60;
            return seconds < 10 ? "0" + seconds : seconds.ToString();
        }
    }
    
    

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
    }

    private void Start()
    {
        TaskController.Instance.OnTaskFinished += OnTaskFinished;

        GameManager.Instance.OnGameStarted += StartTimer;
        GameManager.Instance.OnGameFinished += FinishTimer;
        // StartTimer();
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnGameStarted -= StartTimer;
        GameManager.Instance.OnGameFinished -= FinishTimer;
        TaskController.Instance.OnTaskFinished -= OnTaskFinished;
    }

    private void Update()
    {
        if (!_isWorking) return;
        
        _timeLeft -= Mathf.Min(_timeLeft, Time.deltaTime);
        _text.text = $"{MinutesLeft}:{SecondsLeft} {_additionalText}";
        _slider.value = Mathf.Min(1, _timeLeft / _gameTime);
            
        if (_timeLeft == 0)
        {
            GameManager.Instance.FinishGame();
        }
    }

    public void StartTimer()
    {
        _timeLeft = _gameTime;
        _isWorking = true;
    }

    private void FinishTimer()
    {
        if (!_isWorking) return;
        
        _text.text = "00:00";
        _isWorking = false;
        OnTimerFinished?.Invoke();
    }

    public void OnTaskFinished()
    {
        AddTime(_taskBonus);
    }

    public void SetMaxTime(float newGameTime)
    {
        _gameTime = newGameTime;
    }
    
    private void AddTime(float time)
    {
        _timeLeft += time;
        StartCoroutine(SetAdditionalText($"<color=green>(+{time} сек.)</color>"));
    }

    private void RemoveTime(float time)
    {
        _timeLeft -= time;
        StartCoroutine(SetAdditionalText($"<color=red>(-{time} сек.)</color>"));
    }
    

    private IEnumerator SetAdditionalText(string newText)
    {
        _additionalText = newText;
        yield return new WaitForSeconds(_additionalTextLifetime);
        _additionalText = "";
    }
}
