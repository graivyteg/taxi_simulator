using System;
using Cinemachine;
using UnityEngine;

namespace DefaultNamespace
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private CinemachineBrain _brain;
        [SerializeField] private Transform _menuPoint;

        private void Start()
        {
            SetMenuState();
            GameManager.Instance.OnGameStarted += SetGameState;
        }

        private void SetMenuState()
        {
            _brain.enabled = false;
            transform.position = _menuPoint.position;
            transform.rotation = _menuPoint.rotation;
        }

        private void SetGameState()
        {
            _brain.enabled = true;
        }
    }
}