using System;
using Entity.MovementControl;
using Level;
using UnityEngine;

namespace Entity
{
    [RequireComponent(typeof(Rigidbody))]
    public class ControllableEntity : MonoBehaviour
    {
        private IVelocityController _velocityController;
        private Rigidbody _rigidbody;

        public event Action<string> OnVelocityControllerChanged;
        public event Action<Vector3> OnWallHit;
        
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        
        private void Update()
        {
            TryUpdateVelocityController();
            
            _rigidbody.velocity = _velocityController.NewVelocity();
        }

        private void TryUpdateVelocityController()
        {
            if (_velocityController != null && !Input.GetKeyDown(KeyCode.Space))
            {
                return;
            }
            
            _velocityController = NewVelocityController();
            OnVelocityControllerChanged?.Invoke(_velocityController.Name);
        }
        
        private IVelocityController NewVelocityController()
        {
            return _velocityController switch
            {
                PlayerInputVelocityController _ => new RandomVelocityController(),
                RandomVelocityController _ => new DvdVelocityController(this),
                DvdVelocityController _ => new PlayerInputVelocityController(),
                _ => new PlayerInputVelocityController()
            };
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.gameObject.TryGetComponent<WallCollision>(out _))
            {
                return;
            }

            var resolveVelocity = collision.impulse / _rigidbody.mass;
            OnWallHit?.Invoke(resolveVelocity);
        }
    }
}
