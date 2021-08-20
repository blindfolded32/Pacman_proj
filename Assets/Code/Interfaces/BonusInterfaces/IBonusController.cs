using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBonusController 
{
    delegate void BonusCollected(object message);
    event BonusCollected ScoreCollect;
    event BonusCollected SpeedCollect;
    event BonusCollected GodModeCollect;
    void OnCollect();
}
