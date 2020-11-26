using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace DontWannaDie
{
    public class SpellLogic : MonoBehaviour
    {
        #region Fields

        [SerializeField] private float _spellSpeed;

        #endregion


        #region UnityMethods
        private void FixedUpdate()
        {
            transform.Translate(Vector3.forward * _spellSpeed);
        }
         

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
                other.gameObject.GetComponent<PlayerController>().Death();
            Destroy(this.gameObject);
        }
        #endregion
    }

}
