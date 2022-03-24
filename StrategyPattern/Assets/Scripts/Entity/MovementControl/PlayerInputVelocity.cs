using System.Collections.Generic;
using UnityEngine;

namespace Entity.MovementControl
{
    public class PlayerInputVelocity : IVelocityController
    {
        public string Name => "Manual";

        private const float Speed = 10.0f;

        private static readonly Dictionary<KeyCode, Vector3> KeyDirectionMap = new Dictionary<KeyCode, Vector3>()
        {
            { KeyCode.UpArrow,    Vector3.forward },
            { KeyCode.DownArrow,  Vector3.back },
            { KeyCode.LeftArrow,  Vector3.left },
            { KeyCode.RightArrow, Vector3.right }
        };

        public Vector3 NewVelocity()
        {
            return Speed * MovementDirectionFromInputs();
        }
        
        private Vector3 MovementDirectionFromInputs()
        {
            var direction = new Vector3();

            foreach (var entry in KeyDirectionMap)
            {
                if (Input.GetKey(entry.Key))
                {
                    direction += entry.Value;
                }
            }

            return Mathf.Approximately(direction.magnitude, 0.0f) ? direction : direction.normalized;
        }
    }
}
