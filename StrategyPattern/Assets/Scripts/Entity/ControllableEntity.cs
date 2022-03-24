using System;
using Entity.MovementControl;
using UnityEngine;
using UnityEngine.UI;

namespace Entity
{
    [RequireComponent(typeof(Rigidbody))]
    public class ControllableEntity : MonoBehaviour
    {
        private IVelocityController _velocityController;
        private Rigidbody _rigidbody;

        public event Action<string> OnCurrentModeChanged;
        
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
            OnCurrentModeChanged?.Invoke(_velocityController.Name);
        }
        
        private IVelocityController NewVelocityController()
        {
            return _velocityController switch
            {
                PlayerInputVelocityController _ => new RandomVelocityController(),
                RandomVelocityController _ => new PlayerInputVelocityController(),
                _ => new PlayerInputVelocityController()
            };
        }
    }
}
