using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Labyrinth
{
    public sealed class Exit : Bonus
    {
        [SerializeField] private Material _material;

        private void Awake()
        {
            _audioClip = GetComponent<AudioSource>();
            _image = GameObject.Find("Canvas/YouWin").GetComponentInChildren<Image>();
            _material = GetComponent<Renderer>().material;
        }
        protected override void Interaction()
        {   
            _audioClip.Play();
            _image.enabled = !_image.enabled;
        }
    }
}