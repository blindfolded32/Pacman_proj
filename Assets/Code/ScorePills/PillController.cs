
using UnityEngine;

public class PillController : ICollectableController
{
    public float PillCount { get; private set; }
    private readonly ICollectableModel _collectableModel;
    private readonly ICollectableView _collectableView;

    public event ICollectableController.ScorePill CollectPill;

    public PillController(ICollectableModel pillModel, ICollectableView pillView)
    {
        _collectableModel = pillModel;
        _collectableView = pillView;
        
    }

    public void OnCollect()
    {
        if (_collectableView.collected)
        {
            PillCount--;
            CollectPill?.Invoke(PillCount);
        }
    }
}
