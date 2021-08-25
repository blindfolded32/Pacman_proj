using System;
using System.Collections.Generic;
using UnityEngine;

public class CollectableView : MonoBehaviour, ICollectableView, IDisposable
{
    private Animator _animator;
    private static readonly int BonusOn = Animator.StringToHash("BonusOn");

    public event ICollectableView.ScorePill eatPill;

    private void Awake()
    {
        if (!TryGetComponent<Animator>(out _animator)) throw new ArgumentNullException($"{gameObject.name} has no Animator");
    }

       public void BonusColored() =>_animator.SetTrigger(BonusOn);

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerView>())
        {
           
            eatPill?.Invoke(true);
            Dispose(gameObject);
        }
       
    }

    public void Dispose(GameObject obj) => Destroy(obj);

}
