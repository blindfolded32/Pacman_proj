using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Scripts.Player
{ 
 [Serializable]   
public class Player_affix 

{
        public int _pill_score = 100;
        public float _affix_score = 1.0f;
        public float _affix_move = 1.0f;

        public void Player_speed(bool affected,float affix, int duration )
      {
            float _start_time = Time.time;
            if (!(affected && _start_time + Time.time < duration)) _affix_move = 1.0f;
            else _affix_move = affix;

        }

    public void Score_affix (bool affected, float affix, int duration)
    {
        float _start_time = Time.time;
            if (!(affected && _start_time + Time.time < duration)) _affix_score = 1.0f;
            else _affix_score = affix;

    }
    }
}
