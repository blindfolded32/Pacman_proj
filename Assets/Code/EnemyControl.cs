using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Scripts.Game
{

public class EnemyControl : MonoBehaviour
{
        private NavMeshAgent _navMeshAgent;
        protected Bonuses[] _bonuses;

        private void Start()
        {
            if (TryGetComponent<NavMeshAgent>(out _navMeshAgent)) _navMeshAgent.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
            else throw new Exception();

            
        }
            private void OnBonusCollect()
            {
                _bonuses = FindObjectsOfType<Bonuses>();
            foreach (var bonus in _bonuses)
                bonus.OnCollected += (type, mod) => { if (type == "GodMode") Flee(); };
            }

        private void Flee()
        {
            Debug.Log("KAWABANGA");
        }
    }
}
