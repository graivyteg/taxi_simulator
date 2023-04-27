using System;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class Menu : MonoBehaviour
{
    [SerializeField] protected float _fadingTime = 0.3f;
    
    protected CanvasGroup _group;
    protected bool _isAnimating = false;


    protected virtual void Awake()
    {
        _group = GetComponent<CanvasGroup>();
    }

    public virtual void SetEnabled(bool isEnabled)
    {
        _group.interactable = isEnabled;
        _group.alpha = isEnabled ? 1 : 0;
        _group.blocksRaycasts = isEnabled;
    }
    
    public virtual LTDescr FadeIn(Action onComplete = null, bool returnBack = false)
    {
        if (_isAnimating) return null;

        return LeanTween.alphaCanvas(_group, 1, _fadingTime)
            .setOnStart(() =>
            {
                _isAnimating = true;
                _group.interactable = true;
                _group.blocksRaycasts = true;
            })
            .setOnComplete(() =>
            {
                _isAnimating = false;
                onComplete?.Invoke();
                if(returnBack) FadeOut();
            }).setIgnoreTimeScale(true);
    }

    public virtual LTDescr FadeOut()
    {
        if (_isAnimating) return null;

        return LeanTween.alphaCanvas(_group, 0, _fadingTime)
            .setOnStart(() =>
            {
                _isAnimating = true;
                _group.blocksRaycasts = false;
                _group.interactable = false;
            })
            .setOnComplete(() =>
            {
                _isAnimating = false;
            }).setIgnoreTimeScale(true);
    }
}