using System.IO;
using UnityEngine;

namespace Code.SaveLoad
{
    public class RepositorySave : ISaveData<IBonusController>
    {
        
        private readonly IActionInterface<SavedData> _data;
        private readonly JsonActions<SavedData> _json;

        private const string _folderName = "dataSave";
        private const string _fileName = "data.txt";
        private readonly string _path;
   

        public RepositorySave()
        {
            _data = new BonusPrefs();
            _json = new JsonActions<SavedData>();
            _path = Path.Combine(Application.dataPath, _folderName);
        }
        
        public void Save(IBonusController data)
        {
            if (!Directory.Exists(Path.Combine(_path)))
            {
                Directory.CreateDirectory(_path);
            }

            if (!File.Exists(Path.Combine(_path, _fileName)))
            {
                File.Create(Path.Combine(_path, _fileName));
            }

            var save = new SavedData
            {
                Position = data.SpawnPosition,
                Name = "bonus",
                IsEnabled = true
            };
       // _data.Save(save,Path.Combine(_path, _fileName));
        _json.Save(save,Path.Combine(_path, _fileName));
        Debug.Log($"saved {save} to {Path.Combine(_path, _fileName)} ");
        }

        public void Load(IBonusController data)
        {
           
        }

    }
}