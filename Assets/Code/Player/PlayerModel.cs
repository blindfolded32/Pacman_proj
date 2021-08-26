using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerModel : IPlayerModel
{
    public float X { get; }

    public float Y { get; }

    public float Z { get; }

    public float Speed { get; set; }

    public bool _isPlayerInvulnerable { get; set; }

    public PlayerModel(float speed) : this() => Speed = speed;
}
