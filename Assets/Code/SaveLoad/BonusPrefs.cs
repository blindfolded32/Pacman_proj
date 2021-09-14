using UnityEngine;
using  static UnityEngine.Object;

namespace Code.SaveLoad
{
    public class BonusPrefs : IActionInterface<SavedData>
    {
        public void Save(SavedData data, string path = null)
        {
            var Bonuses = FindObjectsOfType<BonusView>();
            foreach (var bonus in Bonuses)
            {
                data.Name = bonus.gameObject.name;
                data.Position.X = bonus.gameObject.transform.position.x;
                data.Position.Y = bonus.gameObject.transform.position.y;
                data.Position.Z = bonus.gameObject.transform.position.z;
            }
        }

        public SavedData Load(string path = null)
        {
            var result = new SavedData();
            
            return result;
        }
    }
}