using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace DefaultNamespace
{
    public class MenuContainer : MonoBehaviour
    {
        [SerializeField] private List<NamedMenu> _menus;
        [SerializeField] private bool _switchDefaultOnStart;

        [ShowIf("_switchDefaultOnStart")] [SerializeField]
        public int DefaultId;

        private Menu _currentMenu;

        public event Action OnInitialized;

        private void Start()
        {
            for (int i = 0; i < _menus.Count; i++)
            {
                if (_switchDefaultOnStart && i == DefaultId)
                {
                    _currentMenu = _menus[i];
                    _currentMenu.SetEnabled(true);
                    continue;
                }
                _menus[i].SetEnabled(false);
            }
            
            OnInitialized?.Invoke();
        }
        
        public void ChangeMenu(string nextMenu)
        {
            if (_currentMenu != null)
            {
                _currentMenu.FadeOut();
            }

            _currentMenu = _menus.Find(menu => menu.Name == nextMenu);
            _currentMenu.FadeIn();
        }

        [Button()]
        public void SwitchOnCurrent()
        {
            if(_currentMenu == null) return;
            
            _currentMenu.FadeIn();
        }

        [Button()]
        public void SwitchOffCurrent()
        {
            if(_currentMenu == null) return;
            
            _currentMenu.FadeOut();
        }
    }
}