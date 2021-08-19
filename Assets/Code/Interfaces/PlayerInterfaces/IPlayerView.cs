using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerView
{
    Transform Transform { get; }
    Vector3 MoveDirection { get; set; }
    CharacterController MovementControl { get; set; }
    void Movement();

}
