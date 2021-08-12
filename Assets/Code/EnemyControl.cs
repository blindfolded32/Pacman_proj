using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Scripts.Game
{

public class EnemyControl : MonoBehaviour, IDisposable
{
        private NavMeshAgent _navMeshAgent;
        protected Bonuses[] _bonuses;
        private bool _isFleeing = false;

        private void Start()
        {
            if (TryGetComponent<NavMeshAgent>(out _navMeshAgent)) _navMeshAgent.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
            else throw new ArgumentNullException($"{gameObject.name} has no NavMesh");    
        }
            private void OnBonusCollect()
            {
                _bonuses = FindObjectsOfType<Bonuses>();
            foreach (var bonus in _bonuses)
                bonus.OnCollected += (type, mod) => { if (type == "GodMode") Flee(); };
            }
        private void Update()
        {
            _navMeshAgent.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
        }
        private void Flee()
        {
            _isFleeing = true;
            Debug.Log("KAWABANGA");
           // _navMeshAgent.
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (_isFleeing) Dispose(gameObject);
            }
        }

        public void Dispose(GameObject obj) => Destroy(obj);
    }
}
