using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Labyrinth
{
    public class GameManager : MonoBehaviour, IDisposable
    {
        private GameObject _player;
        private Canvas _canvas;
        private Bonus[] _interactiveObject;
        public Sprite _winImage;
        public Sprite _looseImage;
        private AudioClip _looseSnd;
        private AudioClip _winSnd;

        public DisplayEndGame _displayEndGame;
        private void Awake()
        {
            GameManager[] _objs = GameObject.FindObjectsOfType<GameManager>();
            if (_objs.Length > 1) Destroy(this.gameObject);
            DontDestroyOnLoad(this.gameObject);
            _player = GameObject.FindGameObjectWithTag("Player");
            _canvas = FindObjectOfType<Canvas>();
            _winImage = Resources.Load<Sprite>("_youWin");
            _looseImage = Resources.Load<Sprite>("_youLoose");
            _looseSnd = Resources.Load<AudioClip>("_looseSnd");
            _winSnd = Resources.Load<AudioClip>("_winSnd");

            _displayEndGame = new DisplayEndGame(_canvas, _winImage, _looseImage, _looseSnd, _winSnd);
            _interactiveObject = FindObjectsOfType<Bonus>();
            foreach (var o in _interactiveObject)
            {
                if (o is BadBonus badBonus)
                {
                    badBonus.CaughtPlayer += endGame;
                    badBonus.CaughtPlayer += _displayEndGame.GameOver;
                }
                if (o is Exit exit)
                {
                    exit.wonTheGame += endGame;
                    exit.wonTheGame += _displayEndGame.YouWin;
                }
            }
        }

        void Update()
        {

        }
        public void badAction(int mod)
        {
            if (mod > 3)
            {
                mod = Random.Range(1, 3);
            }

            if (mod == 1)
            {
                Debug.Log("offLight");
                float time = Random.Range(3.0f, 10.0f);
                StartCoroutine(OffLight(time));
            }
            else if (mod == 2)
            {
                Debug.Log("lowSpeed");
                float speed = Random.Range(0.1f, 2.0f);
                float time = Random.Range(5.0f, 15.0f);
                StartCoroutine(PlayerSpeed(speed, time));
            }
            else if (mod == 3)
            {
                Debug.Log("cameraShake");
                float time = Random.Range(1, 3);
                CameraShake _shake = FindObjectOfType<CameraShake>();
                _shake.enabled = !_shake.enabled;
                _shake.shakeDuration = time;
            }
        }

        public void endGame()
        {
            print("GAME OVER");
            Destroy(_player);
        }

        public void Dispose()
        {

        }

        public IEnumerator OffLight(float time)
        {
            FindObjectOfType<Light>().intensity = 0.1f;
            yield return new WaitForSeconds(time);
            FindObjectOfType<Light>().intensity = 1.0f;
        }

        public IEnumerator PlayerSpeed(float speed, float time)
        {
            try
            {
                FindObjectOfType<Player>().Speed = speed;
            }
            catch (NullReferenceException)
            {
                yield break;
            }

            yield return new WaitForSeconds(time);
            FindObjectOfType<Player>().Speed = 5;
        }
    }

}
