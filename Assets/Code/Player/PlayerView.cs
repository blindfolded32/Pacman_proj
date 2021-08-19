using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour, IPlayerView
{
    public Transform Transform { get; private set; }
    public Vector3 MoveDirection { get; set; }
    public CharacterController MovementControl { get; set; }

    private void Awake()
    {
        Transform = transform;
        MovementControl = GetComponent<CharacterController>();
    }

    public void Movement()
    {
        
    }
}
