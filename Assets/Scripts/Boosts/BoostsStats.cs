
using UnityEngine;

namespace Boosts
{
    public class BoostsStats : MonoBehaviour
    {
        [SerializeField]
        public float BoostEffectLength = 10f;

        [SerializeField] 
        public Vector3 PlatformSizeUp; 

        [SerializeField] 
        public Vector3 PlatformSizeDown;
        
        [SerializeField] 
        public Vector3 BallSizeUp;
        
        [SerializeField] 
        public Vector3 BallSizeDown;

        [SerializeField] 
        public float BallSpeedUp = 10f;
        
        public Vector3 BasePlatformSize;

        public Vector3 BaseBallSize;

        private void Start()
        {
            PlatformSizeUp = BasePlatformSize * 1.5f;
            PlatformSizeDown = BasePlatformSize / 1.5f;

            BallSizeUp = BaseBallSize * 1.5f;
            BallSizeDown = BaseBallSize / 1.5f;
        }
    }
}