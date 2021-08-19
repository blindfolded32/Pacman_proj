using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PillModel : ICollectableModel
{
    public Color Color { get; set; }

    public float X { get; }

    public float Y { get; }

    public float Z { get; }

    public PillModel(Color color) : this() => Color = color;
   
}
