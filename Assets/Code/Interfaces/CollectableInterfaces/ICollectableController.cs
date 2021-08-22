using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectableController 
{
   
    bool gameEnd { get; }
    delegate void ScorePill();
    event ScorePill CollectPill;
    bool OnCollect();
}
