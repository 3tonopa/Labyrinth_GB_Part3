using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Labyrinth
{
    public class GoodBonus : Bonus, IFly, IFlicker
    {
       [SerializeField] private Material _material;
        float heightFly = 6f;

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
        }
        protected override void Interaction()
        {
            Debug.Log("No iteraction");
        }

        public void Fly()
        {
            transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, heightFly), transform.position.z);
        }

        public void Flick()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b, Mathf.PingPong(Time.time, 1.0f));
        }
    }
}
