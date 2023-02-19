using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Labyrinth
{
    public sealed class DisplayEndGame
    {
        private AudioSource _audio;
        private AudioClip _looseSnd;
        private AudioClip _winSnd;
        private Image _image;
        private Sprite _winImage;
        private Sprite _looseImage;

        public DisplayEndGame(Canvas canv, Sprite _win, Sprite _loose, AudioClip _looseS, AudioClip _winS)
        {
            _audio = canv.GetComponent<AudioSource>();
            _image = canv.GetComponentInChildren<Image>();
            _looseImage = _loose;
            _winImage = _win;
            _looseSnd = _looseS;
            _winSnd = _winS;
        }
        public void GameOver()
        {
            _image.enabled = !_image.enabled;
            _image.sprite = _looseImage;
            _audio.clip = _looseSnd;
            _audio.Play();
        }
        public void YouWin()
        {
            _image.enabled = !_image.enabled;
            _image.sprite = _winImage;
            _audio.clip = _winSnd;
            _audio.Play();
        }
    }
}
