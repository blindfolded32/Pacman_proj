using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IBonusCollected : IEventSystemHandler
{
    void OnBonusCollected(Bonuses bonus, PlayerControl player);

    void OnBonusExpired(Bonuses bonus, PlayerControl player);
}
