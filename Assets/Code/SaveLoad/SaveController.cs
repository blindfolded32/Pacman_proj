using UnityEngine;
using static UnityEngine.Object;

namespace Code.SaveLoad
{
    public class SaveController 
    {
        private readonly IBonusController _bonusController;

        private readonly ISaveData<IBonusController> _saveData;
       // private readonly Repository _repository;

       public SaveController(IBonusController bonusController)
       {
           _bonusController = bonusController;
           _saveData = new RepositorySave();
          
       }

       public void Save()
       {
           var Bonuses = FindObjectsOfType<BonusView>();
           foreach (var bonus in Bonuses)
           {
               _saveData.Save(_bonusController);
           }
       }
    }
}