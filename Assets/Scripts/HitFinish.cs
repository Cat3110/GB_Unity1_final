using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace DontWannaDie
{
    public class HitFinish : MonoBehaviour
    {
        #region Fields

        [SerializeField] private UnityEvent _onHitFinish;

        #endregion

        #region UnityMethods

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
                _onHitFinish.Invoke();
        }

        #endregion
    }

}
