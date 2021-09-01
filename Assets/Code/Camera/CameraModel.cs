using UnityEngine;

public struct CameraModel : ICameraModel
{
    public Transform Transform { get; }

    public Quaternion Rotation { get; set; }

    public CameraModel (Quaternion rotation) : this() => Rotation = rotation;
}
