using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct EnemyModel : IEnemyModel
{
    public float X { get; }

    public float Y { get; }

    public float Z { get; }

    public float Speed { get; set; }

    public EnemyModel(float speed) : this() => Speed = speed;
}
