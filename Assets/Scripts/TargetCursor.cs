using System;
using UnityEngine;

public class TargetCursor : MonoBehaviour
{
    [SerializeField] private GameObject _arrow;

    private Transform _target;
    private Vector3 _targetVector;
    private float _lerpValue = 0.3f;

    private void Start()
    {
        _arrow.SetActive(false);
        
        GameManager.Instance.OnGameStarted += OnGameStarted;
        GameManager.Instance.OnGameFinished += OnGameFinished;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnGameStarted -= OnGameStarted;
        GameManager.Instance.OnGameFinished -= OnGameFinished;
    }

    private void Update()
    {
        if (_target == null) return;

        _targetVector = _target.position - transform.position;
        _targetVector.y = 0;
        _lerpValue = 0.3f;
        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            Quaternion.LookRotation(_targetVector, Vector3.up),
            _lerpValue);
    }

    private void OnGameStarted() => _arrow.SetActive(true);
    private void OnGameFinished() => _arrow.SetActive(false);

    public void SetTarget(Transform target)
    {
        if (target == null)
        {
            ResetTarget();
            return;
        }
        _target = target;
        _arrow.SetActive(true);
    }

    public void ResetTarget()
    {
        _arrow.SetActive(false);
        _target = null;
    }
}