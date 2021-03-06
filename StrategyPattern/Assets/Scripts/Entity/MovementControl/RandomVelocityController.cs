using UnityEngine;
using Util;

namespace Entity.MovementControl
{
    public class RandomVelocityController : IVelocityController
    {
        public string Name => "Random";

        private const float MinSpeed = 1.0f;
        private const float MaxSpeed = 10.0f;
        
        private const float MinTimeToMove = 0.3f;
        private const float MaxTimeToMove = 5.0f;

        private float _timer;
        private Vector3 _currentVelocity;

        public RandomVelocityController()
        {
            _timer = -1;
        }
        
        public Vector3 NewVelocity()
        {
            TrySetNewVelocity();
            
            return _currentVelocity;
        }

        private void TrySetNewVelocity()
        {
            _timer -= Time.deltaTime;
            if (_timer > 0)
            {
                return;
            }

            _timer = Random.Range(MinTimeToMove, MaxTimeToMove);

            _currentVelocity = NewRandomVelocity();
        }

        private static Vector3 NewRandomVelocity()
        {
            var speed = Random.Range(MinSpeed, MaxSpeed);

            return speed * Vector3Extension.RandomDirection();
        }
    }
}