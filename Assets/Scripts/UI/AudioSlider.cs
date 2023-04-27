using System;
using UnityEngine;
using UnityEngine.UI;
using AudioType = DefaultNamespace.Audio.AudioType;

namespace UI
{
    [RequireComponent(typeof(Slider))]
    public class AudioSlider : MonoBehaviour
    {
        [SerializeField] private AudioType _type;
        [SerializeField] private float _defaultValue;

        private Slider _slider;

        private void Start()
        {
            _slider = GetComponent<Slider>();
            _slider.onValueChanged.AddListener(OnValueChanged);
        }

        private void Update()
        {
            _slider.value = PlayerPrefs.GetFloat(_type.ToString(), _defaultValue);
        }

        private void OnValueChanged(float newValue)
        {
            PlayerPrefs.SetFloat(_type.ToString(), _slider.value);
        }
    }
}