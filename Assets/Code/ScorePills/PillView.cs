using System;
using UnityEngine;

public class PillView : MonoBehaviour, ICollectableView, IDisposable
{
    private Animator _animator;
    private static readonly int BonusOn = Animator.StringToHash("BonusOn");
    public bool collected { get; private set; }

    private void Awake()
    {
        if (!TryGetComponent<Animator>(out _animator)) throw new ArgumentNullException($"{gameObject.name} has no Animator");
    }

    public void BonusColored() =>_animator.SetTrigger(BonusOn);

    private bool OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return collected = false;
        Dispose(gameObject);
        return collected = true;
    }

    public void Dispose(GameObject obj) => Destroy(obj);

}
