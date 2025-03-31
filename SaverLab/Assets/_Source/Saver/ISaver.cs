using _Source.Data;

namespace _Source.Saver
{
    public interface ISaver
    {
        void Save(GameData data);
        GameData Load();
        void ClearSave();
    }
}

