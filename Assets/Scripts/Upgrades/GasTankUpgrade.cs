using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu]
    public class GasTankUpgrade : Upgrade<GameTimer>
    {
        [SerializeField] private float _newMaxTime;
        
        public override void Apply(GameTimer timer)
        {
            timer.SetMaxTime(_newMaxTime);
        }
    }
}