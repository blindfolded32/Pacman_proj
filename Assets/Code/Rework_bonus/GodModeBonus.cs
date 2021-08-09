using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodModeBonus : Bonuses
{
    private float _duration = 5f;

    protected override void PowerUpPayload()
    {
        base.PowerUpPayload();
        _playerControl.SetInvulnerability(true);
        
    }

    protected override void BonusEnding()
    {
        if (_bonus_state == Bonus_state.IsExpiring)
        {
            return;
        }
        _playerControl.SetInvulnerability(false);
        
        base.BonusEnding();
    }

    private void Update()
    {
        if (_bonus_state == Bonus_state.IsCollected)
        {
            _duration -= Time.deltaTime;
            if (_duration < 0)
            {
                BonusEnding();
            }
        }
    }
}
