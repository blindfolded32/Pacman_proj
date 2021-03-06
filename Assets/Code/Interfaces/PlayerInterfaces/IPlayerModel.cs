using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerModel 
{
    public float X { get; }
    public float Y { get; }
    public float Z { get; }
    public float Speed { get; set; }

    public bool _isPlayerInvulnerable { get; set; }
}
