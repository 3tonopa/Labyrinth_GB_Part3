using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Labyrinth
{
   
    public class CameraController : MonoBehaviour
    {
        [SerializeField]private Player _player;
        private Vector3 _offset;
        private Transform camTransform;
        // private Vector3 _lastPosition;
        // private float _lastTime;
        void Start()
        {
           _player = FindObjectOfType<Player>();
           _offset = transform.position - _player.transform.position;
           camTransform = transform;
           
        }


        void Update()
        {
            if(_player != null)
            {
            camTransform.LookAt(_player.transform);
            }
            // if (_player.GetComponent<Rigidbody>().velocity != Vector3.zero)
            // {
            //     Quaternion target;
            //     float zPolarity = 1;

            //     if (_player.transform.position.z < _lastPosition.z)
            //     {
            //         target = Quaternion.Euler(45, 180, 0);
            //         zPolarity = -1;
            //     }
            //     else
            //     {
            //         target = Quaternion.Euler(45, 0, 0);
            //     }
            //     camTransform.position = _player.transform.position + new Vector3(_offset.x, _offset.y, _offset.z * zPolarity);
            //     camTransform.rotation = Quaternion.Slerp(camTransform.rotation, target, Time.deltaTime * 2f);
            // }

        }
        // void LateUpdate()
        // {
        //     if(Time.time > _lastTime + 2f)
        //     {
        //     _lastPosition = _player.transform.position;
        //     _lastTime = Time.time;
        //     }
        // }
    }
}
