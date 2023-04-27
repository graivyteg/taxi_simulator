using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class SpecialButton : MonoBehaviour
{
    protected Button Button;

    protected virtual void Start()
    {
        Button = GetComponent<Button>();
        Button.onClick.AddListener(OnClick);
    }

    protected abstract void OnClick();
}