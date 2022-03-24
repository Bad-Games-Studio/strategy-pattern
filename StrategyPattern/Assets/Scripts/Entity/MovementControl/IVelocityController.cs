using UnityEngine;

namespace Entity.MovementControl
{
    public interface IVelocityController
    {
        public string Name { get; }

        public Vector3 NewVelocity();
    }
}
