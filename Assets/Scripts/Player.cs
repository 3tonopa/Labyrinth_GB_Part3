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
            _gm = FindObjectOfType<GameManager>();
            _scoreInd = _gm.score._text;
            _hbInd = _gm.hBar;
            _score = 0;
            if (GetComponent<Rigidbody>())
            {
                _rigidbody = GetComponent<Rigidbody>();
            }
            _ground = _transform.position.y;
        }
        private void Update()
        {   if(_score != 0) _scoreInd.text = $"{_score}";
            else _scoreInd.text = "";
            _hbInd.SetValue(_hp);
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
