using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Labyrinth
{
    public sealed class BadBonus : Bonus, IFly, IRotation
    {
        private float heightFly;
        private float speedRotation;
        public int damage;

        private void Awake()
        {
            heightFly = Random.Range(2f, 6f);
            speedRotation = Random.Range(13f, 40f);
            damage = Random.Range(5,20);
        }

        public void Fly()
        {
            transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, heightFly), transform.position.z);
        }

        public void Rotate()
        {
            transform.Rotate(Vector3.up*(Time.deltaTime*speedRotation), Space.World);
        }

        protected override void Interaction()
        {
            Debug.Log($"HP - {damage}");
            _player._hp -= damage; //+++
            // _gameManager.offLight(5.0f); //+++
            // _gameManager.playerSpeed(50.0f, 10.0f); //+++
            // _gameManager.shakeCamera(14.0f); //+++
            
        }
    }
}
