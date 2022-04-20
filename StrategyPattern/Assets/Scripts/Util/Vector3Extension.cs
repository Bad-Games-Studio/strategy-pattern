using UnityEngine;

namespace Util
{
    public static class Vector3Extension
    {
        private const float MinVelocityDirection = -1.0f;
        private const float MaxVelocityDirection = 1.0f;
        
        public static Vector3 RandomDirection()
        {
            var x = Random.Range(MinVelocityDirection, MaxVelocityDirection);
            var z = Random.Range(MinVelocityDirection, MaxVelocityDirection);
            var direction = new Vector3(x, 0, z);

            return Mathf.Approximately(direction.magnitude, 0.0f) ? Vector3.zero : direction.normalized;
        }
    }
}