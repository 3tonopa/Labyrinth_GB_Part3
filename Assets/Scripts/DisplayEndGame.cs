using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Labyrinth
{
    public sealed class DisplayEndGame  
    {
        private GameObject _onScr;
        private AudioClip _looseSnd;
        private AudioClip _winSnd;
        private Image _oSimage;
        private Sprite _winImage;
        private Sprite _looseImage;
        private AudioSource _oSaudio;

        
        public DisplayEndGame(GameObject _onScr, Sprite _win, Sprite _loose, AudioClip _looseS, AudioClip _winS)
        {
            _oSaudio = _onScr.GetComponent<AudioSource>();
            _oSimage = _onScr.GetComponent<Image>();

            _looseImage = _loose;
            _winImage = _win;

            _looseSnd = _looseS;
            _winSnd = _winS;
        }
        public void GameOver()
        {
            _oSimage.enabled = !_oSimage.enabled;
            _oSimage.sprite = _looseImage;
            _oSaudio.clip = _looseSnd;
            _oSaudio.Play();
        }
        public void YouWin()
        {
            _oSimage.enabled = !_oSimage.enabled;
            _oSimage.sprite = _winImage;
            _oSaudio.clip = _winSnd;
            _oSaudio.Play();
        }
        private void CommonActions()
        {
            
            
        }
    }
}
