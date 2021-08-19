using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICameraModel 
{
    Transform Transform { get; }
    Quaternion Rotation { get; set; }
}
