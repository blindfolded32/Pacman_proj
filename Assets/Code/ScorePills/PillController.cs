using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillController : ICollectableController
{
    public float PullCount { get; set; }

    public event ICollectableController.ScorePill CollectPill;

    public void OnCollect()
    {
        throw new System.NotImplementedException();
    }
}
