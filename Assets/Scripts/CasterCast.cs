using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DontWannaDie
{
    public class CasterCast : MonoBehaviour
    {

        #region Fields

        [SerializeField] private float _timeBetweenAttack;
        [SerializeField] private GameObject _spellObject;
        [SerializeField] private Vector3 _spellOffset;

        private Animator _animator;
        private float _actualTime;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _actualTime = _timeBetweenAttack;
            _animator = GetComponent<Animator>();
        }
        private void Update()
        {
            _actualTime -= Time.deltaTime;
            if (_actualTime <= 0)
            {
                Instantiate(_spellObject, transform.position + _spellOffset, transform.rotation);
                _actualTime = _timeBetweenAttack;
                _animator.SetTrigger("Cast");
            }
        }

        #endregion

    }

}