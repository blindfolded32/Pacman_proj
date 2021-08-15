using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Scripts.Game
{

public  interface IEnemyMoving : IEventSystemHandler
    {
        void Flee(Bonuses bonuses, EnemyControl enemyControl);
}
}
