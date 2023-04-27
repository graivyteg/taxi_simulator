using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class RespawnSlider : MonoBehaviour
    {
        [SerializeField] private GameObject _text;
        [SerializeField] private Slider _slider;

        private bool IsRespawning => GameManager.Instance.IsRespawning;

        private void Update()
        {
            GameManager.Instance.IsRespawning = Input.GetKey(KeyCode.R);

            _slider.gameObject.SetActive(IsRespawning);
            _text.gameObject.SetActive(!IsRespawning);
            _slider.value = GameManager.Instance.GetRespawnTimeNormalized();
        }
    }
}