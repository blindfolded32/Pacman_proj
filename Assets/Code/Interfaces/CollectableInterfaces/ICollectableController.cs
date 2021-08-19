using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectableController 
{
    float PullCount { get; set; }
    delegate void ScorePill();
    event ScorePill CollectPill;
    void OnCollect();
}
