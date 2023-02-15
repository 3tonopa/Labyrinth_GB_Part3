using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Labyrinth
{
    public class GameManager : MonoBehaviour
    {
       private Bonus[] _BonusObject;

        private void Awake()
        {
            GameManager[] _objs = GameObject.FindObjectsOfType<GameManager>();
            if (_objs.Length > 1) Destroy(this.gameObject);
            DontDestroyOnLoad(this.gameObject);
            // _BonusObject = FindObjectsOfType<Bonus>();
            // print("length is: " + _BonusObject.Length);
            // for (int i = 0; i < _BonusObject.Length; i++)
            // {
            //     if(_BonusObject[i] == null)
            //     {
            //         continue;
            //     }
            //     else if (_BonusObject[i] is Exit)
            //     {
            //         continue;
            //     }
            //     else
            //     {
            //         _BonusObject[i]._propertyModifier = Random.Range(1,5);
            //     }
            // }

        }

        void Update()
        {

        }

        public void offLight(float time)
        {
            StartCoroutine(OffLight(time));
        }

        public void playerSpeed(float speed, float time)
        {
            StartCoroutine(PlayerSpeed(speed, time));
        }

        public void shakeCamera(float time)
        {
            CameraShake _shake = FindObjectOfType<CameraShake>();
            _shake.enabled = !_shake.enabled;
            _shake.shakeDuration = time;
        }

        public void endGame()
        {
            print("GAME OVER");
        }

        public IEnumerator OffLight(float time)
        {
            FindObjectOfType<Light>().intensity = 0.1f;
            yield return new WaitForSeconds(time);
            FindObjectOfType<Light>().intensity = 1.0f;
        }

        public IEnumerator PlayerSpeed(float speed,float time)
        {
            FindObjectOfType<Player>().Speed = speed;
            yield return new WaitForSeconds(time);
            FindObjectOfType<Player>().Speed = 5;
        }
    }

}
