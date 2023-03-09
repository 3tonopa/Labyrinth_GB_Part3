using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

namespace Labyrinth
{
    public class GameManager : MonoBehaviour, IDisposable
    {
        //GameObjects
        private GameObject _player;
        private GameObject _onScr;
        private GameObjects _go;
        //Lists
        private Bonus[] _interactiveObject;
        private ListExecuteObject _executiveObject;
        //Sprites
        public Sprite _winImage;
        public Sprite _looseImage;
        //AudioClips
        public AudioClip _looseSnd;
        public AudioClip _winSnd;
        //Integers
        private bool pause;
        //Classes
        public ScoreInd score;
        public Healthbar hBar;
        public ScreenMap map;
        //Fonts
        public Font scoreFont;

        private void Awake()
        {
            _go = FindObjectOfType<GameObjects>();
            _player = GameObject.FindGameObjectWithTag("Player");
            _onScr = GameObject.Find("Canvas/OnScreen");

            _winImage = Resources.Load<Sprite>("_youWin");
            _looseImage = Resources.Load<Sprite>("_youLoose");
            _looseSnd = Resources.Load<AudioClip>("_looseSnd");
            _winSnd = Resources.Load<AudioClip>("_winSnd");

            DisplayEndGame _displayEndGame = new DisplayEndGame(_onScr, _winImage, _looseImage, _looseSnd, _winSnd);
            _executiveObject = new ListExecuteObject();
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
            Buttons quit = new Buttons("Quit");
            quit.gObj.GetComponent<Button>().onClick.AddListener(Quit);
            score = new ScoreInd(scoreFont);
            Buttons restart = new Buttons("Restart");
            restart.gObj.GetComponent<Button>().onClick.AddListener(Restart);
            Buttons pause = new Buttons("Pause");
            pause.gObj.GetComponent<Button>().onClick.AddListener(Pause);
            // Buttons save = new Buttons("Save");
            // save.gObj.GetComponent<Button>().onClick.AddListener(Save);
            // Buttons load = new Buttons("Load");
            // load.gObj.GetComponent<Button>().onClick.AddListener(Load);


            hBar = new Healthbar();
            map = new ScreenMap();
        }

        void Update()
        {
            for (var i = 0; i < _executiveObject.Length; i++)
            {
                var executiveObject = _executiveObject[i];
                if (executiveObject == null)
                {
                    continue;
                }
                executiveObject.Execute();
            }
        }
        public void badAction(int mod)
        {
            if (mod > 3)
            {
                mod = Random.Range(1, 3);
            }

            if (mod == 1)
            {
                float time = Random.Range(3.0f, 10.0f);
                Debug.Log($"LIGHT OFF for {time} sec");
                StartCoroutine(OffLight(time));
            }
            else if (mod == 2)
            {
                float speed = Random.Range(0.1f, 2.0f);
                float time = Random.Range(5.0f, 15.0f);
                Debug.Log($"SPEED LOWERED for {time} sec");
                StartCoroutine(PlayerSpeed(speed, time));
            }
            else if (mod == 3)
            {
                float time = Random.Range(1, 3);
                Debug.Log($"CAMERA SHAKE for {time} sec");
                CameraShake _shake = FindObjectOfType<CameraShake>();
                _shake.enabled = !_shake.enabled;
                _shake.shakeDuration = time;
            }
        }

        public void ShowMap(float m)
                 
        {
            float time = Random.Range(10,61);
            Debug.Log($"SHOW MAP for {time} sec");
            StartCoroutine(MapLife(time, m));
        }

        public void endGame()
        {
            Debug.Log("Game Ended");
            Destroy(_player);
            Invoke("Restart", 3.0f);
        }
        void Restart()
        {
            Debug.Log("RESTART");
            Time.timeScale = 1;
            SceneManager.LoadScene("Scenes/Game", LoadSceneMode.Single);
        }
        void Pause()
        {
            Debug.Log("PAUSE");
            pause = !pause;
            if (pause) Time.timeScale = 0;
            else Time.timeScale = 1;
        }
        void Save()
        {
            _go.SaveFile();
        }
        void Load()
        {
            _go.LoadFile();
        }
        void Quit()
        {
            Application.Quit();
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
        public IEnumerator MapLife(float time, float m)
        {
            map.ShowMap(true, m);
            yield return new WaitForSeconds(time);
            map.ShowMap(false, m);
        }
        
    }

}
