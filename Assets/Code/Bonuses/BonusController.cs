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

    private float _goodMultiplier = 2.0f;
    private float _badMultiplier = 0.5f;

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

    public BonusController() { }

    public void OnCollect()
    {
       
        int chosenDesteny = Range(0, (_bonusDict.Count - 1)); // ïåðåäåëàòü íà íàõîæäåíèå ìàêñ êëþ÷à â ñëîâàðå
        GetBonus(0,_goodMultiplier);//chosenDesteny);
    }

    private void GetBonus(int id, float multiplier)
    {
    
        switch (id)
            {

            case 0: Debug.Log("Speed"); SpeedCollect?.Invoke(multiplier); break;
            case 1: ScoreCollect?.Invoke(true); break;
            case 2: GodModeCollect?.Invoke(true); break;
            default: break;

            }
    }

    public void OnInit()
    {
      
    }
}
