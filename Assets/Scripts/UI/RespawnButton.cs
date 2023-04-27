using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(EventTrigger))]
    public class RespawnButton : MonoBehaviour
    {
        [SerializeField] private Image _fillingImage;
        
        private bool _isPressed = false;
        
        
        private void Update()
        {
            _fillingImage.fillAmount = GameManager.Instance.GetRespawnTimeNormalized();

            if (!Input.GetMouseButton(0) && _isPressed)
            {
                PointerUp();
            }
        }

        public void PointerDown()
        {
            _isPressed = true;
            GameManager.Instance.IsRespawning = true;
        }

        public void PointerUp()
        {
            _isPressed = false;
            GameManager.Instance.IsRespawning = false;
        }
    }
}