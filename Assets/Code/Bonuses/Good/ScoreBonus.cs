using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Game
{

public class ScoreBonus : Bonuses
{ 
        private float _goodScoreMultiplier = 2.0f;
        private float _badScoreMultiplier = 0.5f;
        private float _bonusDuration = 10.0f;


    protected override void GotBonus()
    {
        base.GotBonus();
            if (gameObject.GetComponent("Marker_good")) _playerControl.SetSpeedBoostOn(_goodScoreMultiplier);
            if (gameObject.GetComponent("Marker_bad")) _playerControl.SetSpeedBoostOn(_badScoreMultiplier);
        }

    protected override void BonusEnding()
    {
        _playerControl.SetScoreBoostOff();
        base.BonusEnding();
    }

    private void Update()
    {
        if (IsCollected)
        {

            _bonusDuration -= Time.deltaTime;
            Debug.Log(_bonusDuration);
            if (_bonusDuration < 0)
            {
                BonusEnding();
                Dispose(gameObject);
                }
        }

    }
}
}
