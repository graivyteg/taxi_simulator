using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Hydrant : MonoBehaviour
{
    [SerializeField] private float _impulseToBreak = 800;
    [SerializeField] private float _breakUpForce = 10;

    [SerializeField] private ParticleSystem _waterParticle;

    private Rigidbody _rigidbody;
    
    private bool _isWorking = true;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (_isWorking && other.impulse.magnitude > _impulseToBreak)
        {
            Break();   
        }
    }

    private void Break()
    {
        _isWorking = false;
        _waterParticle.transform.parent = null;
        _waterParticle.Play();
        _rigidbody.constraints = RigidbodyConstraints.None;
        _rigidbody.AddForce(Vector3.up * _breakUpForce * _rigidbody.mass, ForceMode.Impulse);
    }
}
