using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Labyrinth
{
    public sealed class Exit : Bonus, IRotation
    {
        public delegate void WonTheGameChange();
        public WonTheGameChange wonTheGame;

        private void Awake()
        {
            speedRotation = Random.Range(13f, 40f);
        }
        public void Rotate()
        {
            transform.Rotate(Vector3.up*(Time.deltaTime*speedRotation), Space.World);
        }

        protected override void Interaction()
        {   
            wonTheGame();
        }
    }
}