using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Labyrinth
{
    public class GoodBonus : Bonus, IFly, IFlicker, IRotation
    {
        [SerializeField] private Material _material;


        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
            speedRotation = Random.Range(13f, 40f);
            _points = Random.Range(5,20);
            heightFly = 4f;

        }
        protected override void Interaction()
        {
             Debug.Log($"SCORE + {_points}");
            _player._score += _points; //+++
        }

        public void Fly()
        {
            transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, heightFly), transform.position.z);
        }

        public void Flick()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b, Mathf.PingPong(Time.time, 1.0f));
        }

        public void Rotate()
        {
            transform.Rotate(Vector3.left * (Time.deltaTime * speedRotation), Space.World);
        }
    }
}
