using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Labyrinth
{
    public sealed class Player : Unit
    {

        private void Start()
        {
            _hp = 100;
            _transform = GetComponent<Transform>();
            if (GetComponent<Rigidbody>())
            {
                _rigidbody = GetComponent<Rigidbody>();
            }
            _ground = _transform.position.y;
        }
        private void Update()
        {  
            Move();
            if (grounded()) Jump();
        }
        private void Jump()
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(1))
            {
                _rigidbody.AddForce(Vector3.up * 0.3f, ForceMode.Impulse);
            }
        }

    }
}
