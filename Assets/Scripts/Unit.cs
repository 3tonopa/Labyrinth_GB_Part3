using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Labyrinth
{
    public abstract class Unit : MonoBehaviour
    {
        [SerializeField] public Rigidbody _rigidbody;
        public Transform _transform;
        public Text _scoreInd;
        [SerializeField] public float _ground;
        public float Speed = 5;
        public int _hp;
        public int _score;
        private float horizontal;
        private float vertical;
        private Vector3 movement;
        protected Vector3 Normalize(Vector3 mov)
        {
            float x = Mathf.Lerp(0, 1, mov.x);
            float z = Mathf.Lerp(0, 1, mov.z);
            if (mov.x < _transform.position.x) x = x * -1;
            if (mov.z < _transform.position.z) z = z * -1;
            return new Vector3(x, 0f, z);
        }
        protected bool grounded()
        {
            if ((Mathf.Abs(_transform.position.y - _ground)) < 1.0f) return true;
            else return false;
        }
        protected void Move()
        {
            if (_rigidbody)
            {
                if (Input.GetMouseButton(0))
                {
                    RaycastHit hit;
                    Ray ray = FindObjectOfType<Camera>().GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out hit))
                    {
                        movement = Normalize(new Vector3(hit.point.x, 0f, hit.point.z));
                    }
                }
                else
                {
                    horizontal = Input.GetAxis("Horizontal");
                    vertical = Input.GetAxis("Vertical");
                    movement = new Vector3(horizontal, 0f, vertical);
                }
                _rigidbody.AddForce(movement * Speed);
            }
            else Debug.Log("No Rigidbody");
        }
    }
}

