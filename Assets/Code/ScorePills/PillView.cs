using System;

using UnityEngine;

public class PillView : MonoBehaviour, ICollectableView
{
    public Animator animator { get; set; }
    private static readonly int BonusOn = Animator.StringToHash("BonusOn");

    private void Awake()
    {
        if (!TryGetComponent<Animator>(out Animator animator)) throw new ArgumentNullException($"{gameObject.name} has no Animator");
    }

    public void BonusColored()
    {
        animator.SetTrigger(BonusOn);
    }
}
