using _Source.Data;
using UnityEngine;

namespace _Source.Saver
{
    public class PlayerPrefsSaver : ISaver
    {
        private const string ScoreKey = "Score";
        private const string PlayTimeKey = "PlayTime";

        public void Save(GameData data)
        {
            PlayerPrefs.SetFloat(ScoreKey, data.score);
            PlayerPrefs.SetFloat(PlayTimeKey, data.playTime);
            PlayerPrefs.Save();
        }

        public GameData Load()
        {
            GameData data = new GameData
            {
                score = PlayerPrefs.GetFloat(ScoreKey),
                playTime = PlayerPrefs.GetFloat(PlayTimeKey)
            };
            return data;
        }
        
        public void ClearSave()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}