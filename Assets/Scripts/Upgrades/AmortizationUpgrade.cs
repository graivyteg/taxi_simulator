using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu]
    public class AmortizationUpgrade : CarUpgrade
    {
        [SerializeField] private int _newSteeringAngle;
        
        public override void Apply(PrometeoCarController car)
        {
            car.maxSteeringAngle = _newSteeringAngle;
        }
    }
}