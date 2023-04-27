using System;
using UnityEngine;

public class TaskController : MonoBehaviour
{
    public static TaskController Instance;
    
    [SerializeField] private RandomSpawner _startTaskSpawner;
    [SerializeField] private RandomSpawner _finishTaskSpawner;

    [SerializeField] private TargetCursor _cursor;

    public event Action OnTaskStarted;
    public event Action OnTaskFinished;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
    }
    
    private void Start()
    {
        GameManager.Instance.OnGameStarted += OnGameStarted;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnGameStarted -= OnGameStarted;
    }

    private void OnGameStarted()
    {
        _finishTaskSpawner.TryDestroyLast();
        GenerateStartTask();
    }
    
    public void StartTask()
    {
        GenerateFinishTask();
        OnTaskStarted?.Invoke();
    }
    
    public void FinishTask()
    {
        GenerateStartTask();
        OnTaskFinished?.Invoke();
    }

    private void GenerateStartTask()
    {
        var target = _startTaskSpawner.SpawnObject();
        _cursor.SetTarget(target.transform);
    }

    private void GenerateFinishTask()
    {
        var target = _finishTaskSpawner.SpawnObject();
        _cursor.SetTarget(target.transform);
    }
    
}