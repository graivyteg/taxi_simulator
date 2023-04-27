using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Water : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("WaterPoint"))
            {
                GameManager.Instance.FinishGame();
            }
        }
    }
}