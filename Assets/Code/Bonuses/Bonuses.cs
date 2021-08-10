using UnityEngine;
using static UnityEngine.Debug;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Scripts.Game
{
    public class Bonuses : MonoBehaviour, IDisposable
    {
        private GameObject go;
        private EnemyControl[] _enemyGO;
        protected PlayerControl _playerControl;
        protected bool IsExpiring = true;
        protected bool IsCollected = false;
        public delegate void EnemyFlee();
        public event EnemyFlee enemyFleeing;
        void Start()
        {
            go = GameObject.FindGameObjectWithTag("Player");
        }

        void OnTriggerEnter(Collider other)
        {
            BonusCollected(other.gameObject);
        }

        void BonusCollected(GameObject go_player)
        {

            if (!go_player.CompareTag("Player"))
            {
                return;
            }

            if (IsCollected ||!IsExpiring)
            {
                return;
            }
            IsCollected= true;
            _playerControl = go_player.GetComponent<PlayerControl>();

            _enemyGO = GameObject.FindObjectsOfType<EnemyControl>();
            
          /*  foreach (GameObject enemy in _enemyGO)
            {
                EnemyControl enemyControl = enemy.GetComponent<EnemyControl>();

                ExecuteEvents.Execute<IEnemyMoving>(enemy, null, (x, y) => x.Flee(this,enemyControl));
            }*/
            GotBonus();
            ExecuteEvents.Execute<IBonusCollected>(go, null, (x, y) => x.OnBonusCollected(this, _playerControl));  // сделать под словари
            ExecuteEvents.Execute<IBonusCollected>(go, null, (x, y) => x.OnPillBonusCollected(this, _playerControl)); // сделать под словари

        }
        protected virtual void GotBonus()
        {
            Log("Got It: ");
        }
        protected virtual void BonusEnding()
        {
            if (IsExpiring)
            {
                return;
            }
            IsExpiring = true;
            ExecuteEvents.Execute<IBonusCollected>(go, null, (x, y) => x.OnBonusExpired(this, _playerControl));
        }

        public void Dispose(GameObject obj) => Destroy(obj);}
}
