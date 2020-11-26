using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DontWannaDie
{
    public class EnemySpawn : MonoBehaviour
    {

        #region PrivateData

        private enum EnemyType
        {
            None    = 0,
            Spider  = 1,
            Caster  = 2
        }

        #endregion


        #region Fields

        [SerializeField] private EnemyType enemyType;
        [SerializeField] private GameObject _enemyObject;
        [SerializeField] private GameObject _spawnWaypoint;

        #endregion


        #region UnityMethods

        private void Start()
        {
            GameObject enemy = Instantiate(_enemyObject, transform.position, transform.rotation);
            if (_spawnWaypoint)
                enemy.GetComponent<SpiderMooveController>().destinationObject = _spawnWaypoint;
            Destroy(this.gameObject);
        }

        #endregion
    }
}

