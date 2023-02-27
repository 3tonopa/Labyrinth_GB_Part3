using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Labyrinth
{
    public sealed class BadBonus : Bonus, IText, IFly, IRotation
    {
        public delegate void CaughtPlayerChange();
        public CaughtPlayerChange CaughtPlayer;
       

        private void Awake()
        {
            heightFly = Random.Range(2f, 6f);
            speedRotation = Random.Range(13f, 40f);
            _propertyModifier = Random.Range(1,5);
            _damage = Random.Range(5,20);
            if (_propertyModifier == 4) _damage = 100;
        }
        public void Fly()
        {
            transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, heightFly), transform.position.z);
        }
        public void Rotate()
        {
            transform.Rotate(Vector3.up*(Time.deltaTime*speedRotation), Space.World);
        }
        public void Text()
        {
            try
            {
            ui.text = $"Damage: {_damage} \n PM: {_propertyModifier}";
            }
            catch (MissingReferenceException)
            {
                return;
            }

        }
        protected override void Interaction()
        {
            Debug.Log($"HP - {_damage}");
            _player._hp -= _damage; //+++
            if(_player._hp <= 0) CaughtPlayer();
            _gameManager.badAction(_propertyModifier); //+++
        }
    }
}
