using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Labyrinth
{
    public sealed class Exit : Bonus, IRotation, IFly
    {
        public delegate void WonTheGameChange();
        public WonTheGameChange wonTheGame;

        private void Awake()
        {
            speedRotation = Random.Range(13f, 40f);
            heightFly = 4f;
        }
        public void Rotate()
        {
            transform.Rotate(Vector3.up*(Time.deltaTime*speedRotation), Space.World);
        }

        public void Fly()
        {
            if (_player._score > 50) heightFly =2f;
            
            transform.position = new Vector3(transform.position.x,heightFly, transform.position.z);
            
        }

        protected override void Interaction()
        {   
            wonTheGame();
        }
    }
}