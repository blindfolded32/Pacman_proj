using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Scripts.Player
{
public class Bonus_types : IColletable

{
        private List<Bonus_types> _positivBonus;
    private List <Bonus_types> _negativBonus;
   
    private Player_affix _affix;
        public Bonus_types() { }
    public Bonus_types (int _id, string _descr, float _duration) { }
        public void Fill_bonus()
    {
        _positivBonus.Add(new Bonus_types(1,"Speed double",30));
        _positivBonus.Add(new Bonus_types (2,"God Mode",10));
        _positivBonus.Add(new Bonus_types(3,"score x2",60));

        _negativBonus.Add(new Bonus_types(1, "Speed slow", 30));
        _negativBonus.Add(new Bonus_types(2, "Permadeath", 0));
        _negativBonus.Add(new Bonus_types(3, "Lower Score", 0));
    }

        public void Speed_Collected() //Допилить
        {
            _affix.Player_speed(true, 2, 30);
           
        }
        public void Score_Collected() //Допилить
        {
            _affix.Score_affix(true, 2, 30);

        }
    }
}

