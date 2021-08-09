using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Player
{

public class Bonus_marker : MonoBehaviour, IDisposable
{
        private Bonus_types _bonus;
        private void Start()
        {
            _bonus = new Bonus_types();
        }

        public void Dispose(GameObject obj)
        {
            Destroy(obj);
        }

        private void OnTriggerEnter(Collider other)
    {
            if (other.CompareTag("Player"))
            {
              //  _bonus.Choose_bonus();
                Dispose(this.gameObject);
            }
    }
        
}
}
