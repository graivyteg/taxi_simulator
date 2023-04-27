using System;
using UnityEngine;

public abstract class CarStopTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<Player>())
        {
            Action(other.GetComponentInParent<Player>());
        }
    }

    protected abstract void Action(Player player);
}