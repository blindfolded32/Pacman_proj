using System.Collections.Generic;
using static UnityEngine.Object;
using static UnityEngine.Random;
using UnityEngine;


public class BonusController : IBonusController
{
    public event IBonusController.BonusCollected ScoreCollect;
    public event IBonusController.BonusCollected SpeedCollect;
    public event IBonusController.BonusCollected GodModeCollect;

    private readonly IBonusModel _bonusModel;
    private readonly IBonusView _bonusView;

    private Dictionary <int, string> _bonusDict = new Dictionary<int, string> { { 0, "Move" },{1, "Score" },{2, "GodMode"} }; 

    public BonusController (IBonusModel bonusModel)
    {
        BonusView[] bonuses = FindObjectsOfType<BonusView>();
        foreach (var bonus in bonuses)
        {
            _bonusModel = bonusModel;
            _bonusView = bonus;
            bonus.bonusPickedUp += () => OnCollect();
        }
    }

    public void OnCollect()
    {
        //throw new KeyNotFoundException("AAAAAAA");
        int chosenDesteny = Range(0, (_bonusDict.Count - 1)); // переделать на нахождение макс ключа в словаре
        GetBonus(0);//chosenDesteny);
    }

    private void GetBonus(int id)
    {
        switch (id)
            {

            case 0: Debug.Log("Speed"); SpeedCollect?.Invoke(true); break;
            case 1: ScoreCollect?.Invoke(true); break;
            case 2: GodModeCollect?.Invoke(true); break;
            default: break;

            }
    }
}
