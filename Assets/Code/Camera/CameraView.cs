using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour, ICameraView
{
    public Camera Camera { get; private set; }

    
    private void Awake()
    {
        Camera = Camera.main;
    }
}
