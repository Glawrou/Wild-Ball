using UnityEngine;

public abstract class SaveController : MonoBehaviour
{
    protected const string KeySaveData = "SaveData";

    public abstract SaveData Get();
    public abstract void Set(SaveData saveData);
    public abstract void Clear();
    public abstract void Save();
}
