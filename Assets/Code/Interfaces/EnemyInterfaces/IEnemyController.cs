using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public interface IEnemyController 
{
    NavMeshAgent NavMeshAgent {get; }
    void OnUpdate();
}
