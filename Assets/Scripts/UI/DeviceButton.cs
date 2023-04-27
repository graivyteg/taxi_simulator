using System;
using UnityEngine;

namespace UI
{
    public class DeviceButton : SpecialButton
    {
        [SerializeField] private string _deviceName;
        
        private void Update()
        {
            Button.interactable = PlayerPrefs.GetString("Device", "PC") != _deviceName;
        }

        protected override void OnClick()
        {
            PlayerPrefs.SetString("Device", _deviceName);
        }
    }
}