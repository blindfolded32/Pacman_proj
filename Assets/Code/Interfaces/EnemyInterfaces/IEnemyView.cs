using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public interface IEnemyView 
{
    Transform Transform { get; set; }

    delegate void EnemyKilled();
    event EnemyKilled OnKill;
   void ChildCourutine(IEnumerator enumerator);
    void MoveEnemy();
    NavMeshAgent _navMeshAgent { get; set; }
}
