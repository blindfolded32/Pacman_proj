using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public interface IEnemyController 
{
    bool IsFleeing { get; }
    void OnUpdate();
}
