using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Animator))]
public class Human : MonoBehaviour
{
    [SerializeField] private int _animationsCount;
    
    private Animator _animator;
    private static readonly int AnimationId = Animator.StringToHash("AnimationId");

    private void Start()
    {
        _animator = GetComponent<Animator>();
        StartCoroutine(Waiting());
    }

    private IEnumerator Waiting()
    {
        while (true)
        {
            int id = Random.Range(0, _animationsCount);
            _animator.SetInteger(AnimationId, id);
            yield return new WaitForSeconds(Random.Range(1f, 4f));
        }
    }
}
