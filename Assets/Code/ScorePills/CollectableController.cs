using static UnityEngine.Object;
using System.Collections.Generic;
using UnityEngine;

public class CollectableController : ICollectableController
{
    

    public bool gameEnd  { get; private set; }

    private readonly ICollectableModel _collectableModel;
    private ICollectableView _collectableView;
    public event ICollectableController.ScorePill CollectPill;
    private float _count;

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
   
   public bool Eated(bool status)
    {
       if (status)
        {

            Debug.Log(_count);
            _count--;
            if (_count < 200)  return gameEnd = true;
        }
        return false;
    }
    public bool OnCollect() => gameEnd;
    

}
