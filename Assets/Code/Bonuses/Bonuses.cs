using UnityEngine;
using static UnityEngine.Debug;
using System.Collections.Generic;
using System.Collections;
using System;
using Random = UnityEngine.Random;

namespace Scripts.Game
{
    public class Bonuses : MonoBehaviour, IDisposable
    {
        private float _goodMultiplier = 2.0f;
        private float _badMultiplier = 0.5f;
        public delegate void Bonus (string type,object modifier);
        public event Bonus OnCollected;
        

        private List<string> _bonus_types;

        void Start()
        {
            _bonus_types = new List<string>
            {
                "MoveSpeed",
                "Score",
                "GodMode",
            };
        }
        void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player"))
            {
                return;
            }
<<<<<<< HEAD
            IsCollected= true;
            _playerControl = go_player.GetComponent<PlayerControl>();

            _enemyGO = FindObjectsOfType<EnemyControl>();

          foreach (var enemy in _enemyGO)
            {
                EnemyControl enemyControl = enemy.GetComponent<EnemyControl>();
                GameObject temp = enemy.gameObject;
                ExecuteEvents.Execute<IEnemyMoving>(temp, null, (x, y) => x.Flee(this,enemyControl));
            }
            GotBonus();
            ExecuteEvents.Execute<IBonusCollected>(go, null, (x, y) => x.OnBonusCollected(this, _playerControl));  // сделать под словари
            ExecuteEvents.Execute<IBonusCollected>(go, null, (x, y) => x.OnPillBonusCollected(this, _playerControl)); // сделать под словари
=======
            
            if (gameObject.GetComponent("Marker_good")) OnCollected?.Invoke(_bonus_types[Random.Range(0,_bonus_types.Count)],_goodMultiplier);
            if (gameObject.GetComponent("Marker_bad")) OnCollected?.Invoke(_bonus_types[Random.Range(0, _bonus_types.Count)], _badMultiplier);
               
>>>>>>> Dev_work

           Dispose(gameObject);
        }

        public void Dispose(GameObject obj) => Destroy(obj);

       
    }
}
