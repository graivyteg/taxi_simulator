using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public abstract class InjectableText : MonoBehaviour
{
    protected TextMeshProUGUI Text;

    [SerializeField] private string _injectString = "{0}";
    
    private string _firstHalf;
    private string _secondHalf;
    
    protected virtual void Awake()
    {
        Text = GetComponent<TextMeshProUGUI>();
    }

    protected virtual void Start()
    {
        
    }

    private void SplitText()
    {
        _firstHalf = Text.text.Split(_injectString)[0];
        _secondHalf = Text.text.Split(_injectString)[1];
    }

    protected abstract string GetValue();

    public virtual void UpdateText()
    {
        if (_firstHalf == null || _secondHalf == null)
        {
            SplitText();
        } 
        Text.text = _firstHalf + GetValue() + _secondHalf;
    }
}