using UnityEngine;
using Util;

namespace Entity.MovementControl
{
    public class DvdVelocityController : IVelocityController
    {
        public string Name => "DVD";

        private const float Speed = 10.0f;
        private Vector3 _currentVelocity;

        private readonly ControllableEntity _referenceObject;
        
        public DvdVelocityController(ControllableEntity referenceObject)
        {
            _referenceObject = referenceObject;
            _referenceObject.OnWallHit += BounceOffWall;

            _currentVelocity = Speed * Vector3Extension.RandomDirection();
        }
        
        ~DvdVelocityController()
        {
            _referenceObject.OnWallHit -= BounceOffWall;
        }
        
        public Vector3 NewVelocity()
        {
            return _currentVelocity;
        }

        private void BounceOffWall(Vector3 collisionResolveVelocity)
        {
            _currentVelocity += 2 * collisionResolveVelocity;
        }
    }
}