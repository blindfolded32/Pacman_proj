using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBonus : Bonuses
{
    private float speedMultiplier = 2.0f;
    private float _duration = 10.0f;


    protected override void PowerUpPayload()
    {
        base.PowerUpPayload();
        _playerControl.SetSpeedBoostOn(speedMultiplier);
    }

    protected override void BonusEnding()
    {
        _playerControl.SetSpeedBoostOff();
        base.BonusEnding();
    }

    private void Update()
    {
        if (_bonus_state == Bonus_state.IsCollected)
        {
           
            _duration -= Time.deltaTime;
            Debug.Log(_duration);
            if (_duration < 0)
            {
                BonusEnding();
            }
        }

    }
}
