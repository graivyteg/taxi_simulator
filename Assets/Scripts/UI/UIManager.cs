using System;
using DefaultNamespace;
using UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Space(10)] [SerializeField] private MenuContainer _mainContainer;

    private CanvasGroup _currentMenu;

    private void Start()
    {
        GameManager.Instance.OnGameStarted += OnGameStarted;
        GameManager.Instance.OnGameFinished += OnGameFinished;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnGameStarted -= OnGameStarted;
        GameManager.Instance.OnGameFinished -= OnGameFinished;
    }

    public void OpenMainMenu()
    {
        LoadingScreen.Instance.ReloadScene();
    }

    private void OnGameStarted()
    {
        _mainContainer.ChangeMenu("InGameUI");
    }

    private void OnGameFinished()
    {
        _mainContainer.ChangeMenu("FinishGameMenu");
    }
}