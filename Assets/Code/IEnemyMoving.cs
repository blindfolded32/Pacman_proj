using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Game
{

public  interface IEnemyMoving 
{
        void Flee(Bonuses bonuses, EnemyControl enemyControl);
}
}
