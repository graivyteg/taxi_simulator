using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu]
    public class MaxSpeedUpgrade : CarUpgrade
    {
        [SerializeField] private int _newMaxSpeed;
        [SerializeField] private int _newReverseMaxSpeed;

        public override void Apply(PrometeoCarController car)
        {
            car.maxSpeed = _newMaxSpeed;
            car.maxReverseSpeed = _newReverseMaxSpeed;
        }
    }
}