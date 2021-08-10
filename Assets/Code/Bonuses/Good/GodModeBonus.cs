using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Game
{

public class GodModeBonus : Bonuses
{
    private float _duration = 5f;

    protected override void GotBonus()
    {
        base.GotBonus();
        _playerControl.SetInvulnerability(true);
        
    }

    protected override void BonusEnding()
    {
        if (IsExpiring)
        {
            return;
        }
        _playerControl.SetInvulnerability(false);
        
        base.BonusEnding();
    }

    private void Update()
    {
        if (IsCollected)
        {
            _duration -= Time.deltaTime;
            if (_duration < 0)
            {
                BonusEnding();
                Dispose(gameObject);
                }
        }
    }
}
}
