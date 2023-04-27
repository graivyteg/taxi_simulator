using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu]
    public class TransmissionUpgrade : CarUpgrade
    {
        [SerializeField] private int _newAccelerationMultiplier;
        
        public override void Apply(PrometeoCarController car)
        {
            car.accelerationMultiplier = _newAccelerationMultiplier;
        }
    }
}