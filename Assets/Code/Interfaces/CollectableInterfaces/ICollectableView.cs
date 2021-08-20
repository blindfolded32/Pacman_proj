using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectableView 
{
    Animator animator { get; }
    bool collected { get; }
    void BonusColored();
}
