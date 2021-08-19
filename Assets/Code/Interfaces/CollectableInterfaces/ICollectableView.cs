using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectableView 
{
    Animator animator { get; }

    void BonusColored();
}
