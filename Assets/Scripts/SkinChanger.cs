using System;
using NaughtyAttributes;
using UnityEngine;

namespace DefaultNamespace
{
    public class SkinChanger : MonoBehaviour
    {
        public static SkinChanger Instance;
        
        [SerializeField] private MeshRenderer _renderer;
        
        [Space(20)]
        [SerializeField] private int _mainId;
        [SerializeField] private int _dotsId;
        [SerializeField] private int _glassId;

        [SerializeField] private Skin _testSkin;
        

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else if (Instance != this) Destroy(gameObject);
        }

        private void Start()
        {
            
        }

        [Button()]
        public void ApplyTestSkin()
        {
            UpdateSkin(_testSkin);
        }

        public void UpdateSkin(Skin skin)
        {
            _renderer.materials[_mainId].color = skin.MainColor;
            _renderer.materials[_dotsId].color = skin.DotsColor;
            _renderer.materials[_glassId].color = skin.GlassColor;
        }
    }
}