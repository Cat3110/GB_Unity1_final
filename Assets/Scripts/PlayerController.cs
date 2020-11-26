using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace DontWannaDie
{
    public class PlayerController : MonoBehaviour
    {
        #region PrivateData

        enum PlayerStates
        {
            None = 0,
            Idle = 1,
            Walk = 2,
            Dead = 3
        }

        #endregion


        #region Fields

        [SerializeField] private UnityEvent _onDeath;

        [SerializeField] private float _moveSpeed = 4.0f;
        [SerializeField] private float _rotationSpeed = 50.0f;

        private PlayerStates _playerState;
        private float _translation;
        private float _rotation;
        private Animator _animator;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (_playerState != PlayerStates.Dead)
            {
                _translation = Input.GetAxis("Vertical");
                _rotation = Input.GetAxis("Horizontal");

                if (Input.GetAxis("Vertical") == 0)
                {
                    _playerState = PlayerStates.Idle;
                    _animator.SetBool("isMove", false);
                }
                else
                {
                    _playerState = PlayerStates.Walk;
                    _animator.SetBool("isMove", true);
                }
            }
        }

        private void FixedUpdate()
        {
                transform.Translate(0, 0, _translation * _moveSpeed * Time.fixedDeltaTime);
                transform.Rotate(0, _rotation * _rotationSpeed * Time.fixedDeltaTime, 0);
        }

        #endregion


        #region Methods

        public void Death()
        {
            _playerState = PlayerStates.Dead;
            _animator.SetTrigger("Killed");
            _onDeath.Invoke();
        }

        #endregion
    }
}

