using System;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(MenuContainer))]
public class GameUI : MonoBehaviour
{
    private MenuContainer _container;
    
    [SerializeField] private Slider _respawnSlider;
    [SerializeField] private GameObject _respawnText;

    [SerializeField] private GameObject _pcControls;
    [SerializeField] private GameObject _mobileControls;

    private bool _isPC => DeviceController.IsTypeMobile();

    private void Start()
    {
        _container = GetComponent<MenuContainer>();
        
        GameManager.Instance.OnGameStarted += OnGameStarted;
        GameManager.Instance.OnGameFinished += OnGameFinished;
    }

    private void OnDestroy()
    {
        Time.timeScale = 1;
        GameManager.Instance.OnGameStarted -= OnGameStarted;
        GameManager.Instance.OnGameFinished -= OnGameFinished;
    }

    private void OnGameStarted()
    {
        bool isMobile = DeviceController.IsTypeMobile();
        _pcControls.SetActive(!isMobile);
        _mobileControls.SetActive(isMobile);
    }

    private void OnGameFinished()
    {
        Time.timeScale = 1;
    }

    public void OpenInGameMenu()
    {
        Time.timeScale = 0;
        _container.ChangeMenu("InGameMenu");
    }

    public void CloseInGameMenu()
    {
        Time.timeScale = 1;
        _container.SwitchOffCurrent();
    }


    private void Update()
    {
        _respawnText.gameObject.SetActive(GameManager.Instance.GetRespawnTimeNormalized() == 0);
        _respawnSlider.gameObject.SetActive(GameManager.Instance.GetRespawnTimeNormalized() > 0);
        _respawnSlider.value = GameManager.Instance.GetRespawnTimeNormalized();
    }
}