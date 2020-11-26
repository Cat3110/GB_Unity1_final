using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace DontWannaDie
{
    public class SpiderMooveController : MonoBehaviour
    {
        #region PrivateData

        enum SpiderStates
        {
            None    = 0,
            Move    = 1,
            Attack  = 2
        }

        #endregion


        #region Field

        [SerializeField] private float _spiderSpeed = 2.5f;
        [SerializeField] private float _runSpeedMultiplyer = 4.0f;
        [SerializeField] private float _spiderBiteDistance = 1.0f;

        private NavMeshAgent _agent;
        private Animator _animator;
        private SpiderStates _spiderState = SpiderStates.Move;

        public GameObject destinationObject;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _agent = GetComponent<NavMeshAgent>();
            _agent.speed = _spiderSpeed;
            _agent.destination = destinationObject.transform.position;
        }

        private void Update()
        {
            switch (_spiderState)
            {
                case SpiderStates.Move:
                    _agent.speed = _spiderSpeed;
                    if (_agent.remainingDistance <= _agent.stoppingDistance)
                    {
                        GoNextWaypoint();
                    }
                    break;
                case SpiderStates.Attack:
                    _agent.speed = _spiderSpeed * _runSpeedMultiplyer;
                    _agent.SetDestination(destinationObject.transform.position);
                    if (_agent.remainingDistance <= _agent.stoppingDistance)
                    {
                        _animator.SetTrigger("Bite");
                        destinationObject.GetComponent<PlayerController>().Death();
                    }
                    break;
                default:
                    break;
            }

        }

        private void FixedUpdate()
        {
            
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Attack(other.gameObject);
            }

        }

        #endregion


        #region Methods

        private void Attack(GameObject target)
        {
            destinationObject = target;
            _spiderState = SpiderStates.Attack;
            _animator.SetTrigger("Attack");
            _agent.stoppingDistance = _spiderBiteDistance;
        }
        
        private void GoNextWaypoint()
        {
            destinationObject = destinationObject.GetComponent<WaypointController>().nextWaypoint;
            _agent.SetDestination(destinationObject.transform.position);
        }
            
        #endregion
    }
}

