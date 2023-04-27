using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour
{
    [SerializeField] private Renderer _ground;
    
    public Vector2 Size = Vector2.one;

    public void SetGroundColor(Color color)
    {
        _ground.material.color = color;
    }
}