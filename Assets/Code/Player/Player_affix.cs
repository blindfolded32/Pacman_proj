using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Scripts.Player
{ 
 [Serializable]   
public class Player_affix : MonoBehaviour

{
        public int _pill_score = 100;
        public float _affix_score ;
        public float _affix_move;

        public void Player_speed(float affix, int duration )
      {
            float _start_time = Time.time;
            if (!(_start_time + Time.deltaTime < duration)) _affix_move = 1.0f;
            else _affix_move = affix;
            Debug.Log($"Speeding to {affix} left {duration - (_start_time + Time.deltaTime)}");

        }

    public void Score_affix ( float affix, int duration)
    {
        float _start_time = Time.time;
            if (!(_start_time + Time.time < duration)) _affix_score = 1.0f;
            else _affix_score = affix;

    }
        
    }
}
