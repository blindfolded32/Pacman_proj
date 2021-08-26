using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IEnemyView 
{
    Transform Transform { get; set; }

    delegate void EnemyKilled();
    event EnemyKilled OnKill;
    bool IsFleeing { get; set; }
    void ChildCourutine(IEnumerator enumerator);
}
