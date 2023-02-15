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
        {  // Debug.Log(_hp);
            Move();
            if (grounded()) Jump();
            if (_hp <= 0)
            {
                EndGame();
                Destroy(gameObject);
            }

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
