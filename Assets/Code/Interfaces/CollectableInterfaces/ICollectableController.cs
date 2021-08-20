using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectableController 
{
    float PillCount { get; }
    delegate void ScorePill(float pillsLeft);
    event ScorePill CollectPill;
    void OnCollect();
}
