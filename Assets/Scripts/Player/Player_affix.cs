using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Player
{ 
public class Player_affix 

{
        private Player_move _movement;
    public void Player_speed(bool affected,float affix, int duration )
    {
        float _start_time = Time.time;
        if (affected) while (_start_time + Time.time < duration) _movement.MoveSpeed*= affix;


    }

    public float Player_score (float score, bool affected, float affix, int duration)
    {
        float _start_time = Time.time;
        if (affected) while (_start_time + Time.time < duration) score += affix; //Допилить нормально. кушаешь таблетку и считаем аффикс

        return score;
    }

}
}
