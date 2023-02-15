using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace Labyrinth
{
    public class VirtCamera : MonoBehaviour
    {
        [SerializeField] private Player _player;
        public Transform _tFollowTarget;
        private CinemachineVirtualCamera _vcam;
        void Start()
        {
            _vcam = GetComponent<CinemachineVirtualCamera>();
            _player = FindObjectOfType<Player>();
        }
        void Update()
        {
            if (_player)
            {
                _tFollowTarget = _player.transform;
                _vcam.LookAt = _tFollowTarget;
                _vcam.Follow = _tFollowTarget;
            }
        }
    }

}
