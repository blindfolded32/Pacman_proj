using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Object;
using UnityEngine.AI;


public class EnemyController : IEnemyController
{
    public bool IsFleeing { get; private set; }
    private IEnemyModel _enemyModel;
    private IEnemyView _enemyView;

    private EnemyView[] enemies;
    
    public EnemyController(IEnemyModel enemyModel, IBonusController bonusController)
    {
       enemies = FindObjectsOfType<EnemyView>();
       
        foreach(var enemy in enemies)
        {
        _enemyModel = enemyModel;
        _enemyView = enemy;
        _enemyView._navMeshAgent = enemy.GetComponent<NavMeshAgent>();
       
        }
    }
    
    private void Flee(bool status)
    {

    }
    public void OnUpdate()
    {
      
    }
}
