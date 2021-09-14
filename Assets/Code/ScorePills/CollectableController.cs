using static UnityEngine.Object;
using UnityEngine;

public class CollectableController : ICollectableController
{
    public bool gameEnd  { get; private set; }
    private float _count;

    private readonly ICollectableModel _collectableModel;
    private ICollectableView _collectableView;
    public event ICollectableController.ScorePill CollectPill;

   public CollectableController(ICollectableModel pillModel)
    {
        CollectableView[] pills = FindObjectsOfType<CollectableView>();
        foreach ( var pill in pills)
        {
        _collectableModel = pillModel;
        _collectableView = pill;
        pill.eatPill += (x) => Eated(x);
        }
        _count = pills.Length;
    }
   
   private void Eated(bool status)
    {
       if (status)
        {
            Debug.Log("hrum-hrum");
            CollectPill?.Invoke();
            _count--;
            if (_count < 200)  gameEnd = true;
        }
    }
    public bool OnCollect() => gameEnd;
    

}
