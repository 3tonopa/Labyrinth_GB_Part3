using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Labyrinth
{
    public sealed class Player : Unit
    {
        private void Start()
        {
            _transform = GetComponent<Transform>();
            if (GetComponent<Rigidbody>())
            {
                _rigidbody = GetComponent<Rigidbody>();
            }
        }

        private void Update()
        {
            Move();
        }
    }
}
