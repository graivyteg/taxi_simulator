using System;
using UnityEngine;

[RequireComponent(typeof(PrometeoCarController))]
public class Player : MonoBehaviour
{
    [SerializeField] private Transform _respawnPoint;

    public static Player Instance;
    
    private PrometeoCarController _car;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
    }
    
    private void Start()
    {
        _car = GetComponent<PrometeoCarController>();
        _rigidbody = GetComponent<Rigidbody>();
        
        SetActiveControls(false);

        GameManager.Instance.OnGameStarted += OnGameStarted;
        GameManager.Instance.OnGameFinished += OnGameFinished;
    }
    
    private void OnDestroy()
    {
        if (Instance == this) Instance = null;
        GameManager.Instance.OnGameStarted -= OnGameStarted;
        GameManager.Instance.OnGameFinished -= OnGameFinished;
    }

    public PrometeoCarController GetCar() => _car; 
    public float GetCarSpeed() => _car.carSpeed;

    public void Respawn()
    {
        transform.position = _respawnPoint.position;
        transform.rotation = _respawnPoint.rotation;
    }

    public void SetActiveControls(bool isActive)
    {
        _car.enabled = isActive;
    }

    private void OnGameStarted()
    {
        _rigidbody.constraints = RigidbodyConstraints.None;
        SetActiveControls(true);
        _car.useTouchControls = DeviceController.IsTypeMobile();
    }

    private void OnGameFinished()
    {
        _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        SetActiveControls(false);
    }
}
