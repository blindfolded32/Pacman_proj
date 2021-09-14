using System.Collections;
using UnityEngine;

public class EnemyView : MonoBehaviour, IEnemyView, IDisposable
{
    public Transform Transform { get; set; }
    public bool IsFleeing { get; set; }

    public event IEnemyView.EnemyKilled OnKill;

    public void ChildCourutine(IEnumerator enumerator) => StartCoroutine(enumerator);

    public void Dispose(GameObject obj) => Destroy(obj);

    private void Awake()
    {
        Transform = transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!IsFleeing || !other.GetComponent<PlayerView>()) return;
        OnKill?.Invoke();
        Dispose(gameObject);
    }
}
