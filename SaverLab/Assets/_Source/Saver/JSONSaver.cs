using System.IO;
using _Source.Data;
using UnityEngine;

namespace _Source.Saver
{
    public class JSONSaver : ISaver
    {
        private string _path => Application.persistentDataPath + "/save.json";

        public void Save(GameData data)
        {
            string json = JsonUtility.ToJson(data, true);
            File.WriteAllText(_path, json);
        }

        public GameData Load()
        {
            if (!File.Exists(_path)) return new GameData();
        
            string json = File.ReadAllText(_path);
            return JsonUtility.FromJson<GameData>(json);
        }
        
        public void ClearSave()
        {
            if (File.Exists(_path))
            {
                File.Delete(_path);
            }
        }
    }
}