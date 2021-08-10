using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Game
{

public class SpeedBonus : Bonuses
{

       
        private float _goodSpeedMultiplier = 2.0f;
        private float _badSpeedMultiplier = 0.5f;
        private float _bonusDuration = 10.0f;


    protected override void GotBonus()
    {
        base.GotBonus();
            if (gameObject.GetComponent("Marker_good"))
            {
                _playerControl.SetSpeedBoostOn(_goodSpeedMultiplier);
            }
            if (gameObject.GetComponent("Marker_bad"))
            {
                _playerControl.SetSpeedBoostOn(_badSpeedMultiplier);
            }
    }

    protected override void BonusEnding()
    {
        _playerControl.SetSpeedBoostOff();
        base.BonusEnding();
    }

    private void Update()
    {
        if (IsCollected)
        {
           
            _bonusDuration -= Time.deltaTime;
           // Debug.Log(_duration);
            if (_bonusDuration < 0)
            {
                BonusEnding();
                    Dispose(gameObject);
                }
        }

    }
}
}
