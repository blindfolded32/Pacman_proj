using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Game
{

public class ScoreBonus : Bonuses
{ 
    private float _scoreMultiplier = 2.0f;
    private float _duration = 10.0f;


    protected override void GotBonus()
    {
        base.GotBonus();
        _playerControl.SetScoreBoostOn(_scoreMultiplier);
    }

    protected override void BonusEnding()
    {
        _playerControl.SetScoreBoostOff();
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
}
