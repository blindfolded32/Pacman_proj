using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct BonusModel : IBonusModel
{
    public float X { get; }

    public float Y { get; }

    public float Z { get; }

    public Color color { get; set; }

   // public PrimitiveType type { get; set; }
}
