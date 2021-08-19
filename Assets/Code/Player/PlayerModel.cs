using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerModel : IPlayerModel
{
    public float X { get; }

    public float Y { get; }

    public float Z { get; }

    public float Speed { get; }

    public float Score { get; }

    public bool _isPlayerInvulnerable { get; }

    public PlayerModel(float speed) : this() => Speed = speed;
}
