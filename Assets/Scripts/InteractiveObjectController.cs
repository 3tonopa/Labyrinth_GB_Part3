using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Labyrinth
{
    public class InteractiveObjectController : MonoBehaviour
    {
        public Bonus[] _interactiveObject;

        private void Awake()
        {
            _interactiveObject = FindObjectsOfType<Bonus>();
            //print("length is: " + _interactiveObject.Length);
        }

       
      
        void Update()
        {
            for (int i = 0; i < _interactiveObject.Length; i++)
            {
                if(_interactiveObject[i] == null)
                {
                    continue;
                }

                if (_interactiveObject[i]  is IFly fly)
                {
                    fly.Fly();
                }

                if (_interactiveObject[i] is IRotation rotation)
                {
                    rotation.Rotate();
                }

                if (_interactiveObject[i] is IFlicker flick)
                {
                    flick.Flick();
                }
                if (_interactiveObject[i] is IText text)
                {
                    text.Text();
                }

            }
        }
    }
}
