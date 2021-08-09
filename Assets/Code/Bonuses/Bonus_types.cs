using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Object = UnityEngine.Object;
using UnityEngine.EventSystems;

namespace Scripts.Player
{
    public class Bonus_types : Bonus_marker, IPlayerAffix 

    {
        private List<Bonus_types> _positivBonus = new List<Bonus_types>();
        private List<Bonus_types> _negativBonus = new List<Bonus_types>();
        private Player_affix _affix = new Player_affix();
        GameObject go = GameObject.FindGameObjectWithTag("Player"); // Переделать нормально на listener

        public Bonus_types() { }
        public Bonus_types(int _id, string _descr, float _duration) { }
        public void Fill_bonus()
        {
            _positivBonus.Add(new Bonus_types(1, "Speed double", 30));
            _positivBonus.Add(new Bonus_types(2, "God Mode", 10));
            _positivBonus.Add(new Bonus_types(3, "score x2", 60));

            _negativBonus.Add(new Bonus_types(1, "Speed slow", 30));
            _negativBonus.Add(new Bonus_types(2, "Permadeath", 0));
            _negativBonus.Add(new Bonus_types(3, "Lower Score", 0));
        }
            
        public void Speeding_player(float speedaffix)
        {

            ExecuteEvents.Execute<IPlayerAffix>(go,null, (x,y) =>x.Speeding_player(speedaffix) );                   // 2
                   
        }

        public void Scoring_player(float scoreaffix)
        {
            throw new System.NotImplementedException();
        }
    }
}


