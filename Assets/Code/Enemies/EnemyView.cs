using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyView : MonoBehaviour, IEnemyView, IDisposable
{
    public Transform Transform { get; set; }

    public event IEnemyView.EnemyKilled OnKill;

    public void ChildCourutine(IEnumerator enumerator) => StartCoroutine(enumerator);

    public NavMeshAgent _navMeshAgent { get; set; }

    public void Dispose(GameObject obj) => Destroy(obj);

   private void OnTriggerEnter(Collider other)
    {
        if ( !other.GetComponent<PlayerView>()) return;
        OnKill?.Invoke();
        Dispose(gameObject);
    }

    public void MoveEnemy()
    {
       _navMeshAgent.destination = FindObjectOfType<PlayerView>().transform.position;
    }

    private void Update() /// Как передать в контроллер ссылку на все....
    {
        MoveEnemy();
    }
}
