using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Labyrinth
{
    public abstract class Bonus : MonoBehaviour, IInteractible
    {
        public Player _player;
        public GameManager _gameManager;
        public TextMesh ui;
        public  float heightFly;
        public float speedRotation;
        public int _damage;
        public bool IsInteractible { get; } = true;
        public AudioSource _audioClip;
        public Image _image;
        public int _propertyModifier;
        protected Color _color;

        private void Start()
        {
            _player = FindObjectOfType<Player>();
            _gameManager = FindObjectOfType<GameManager>();
            ui = GetComponentInChildren<TextMesh>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!IsInteractible||!other.CompareTag("Player"))
            {
                return;
            }
            Hide();
            Interaction();
            Destroy(gameObject,2);
        }
        protected abstract void Interaction();
        protected void Hide()
        {
            GetComponent<MeshRenderer>().enabled = !GetComponent<MeshRenderer>().enabled;
            GetComponent<Collider>().enabled = !GetComponent<Collider>().enabled;
            Destroy(ui);
        }
    }
}
