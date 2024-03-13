using UnityEngine;

public class DefaultSaveController : SaveController
{
    private SaveData _save;

    public override void Clear()
    {
        _save = new SaveData();
        Set(_save);
    }

    public override SaveData Get()
    {
        if (_save != null)
        {
            return _save;
        }

        var save = PlayerPrefs.GetString(KeySaveData, string.Empty);
        if (save == string.Empty)
        {
            _save = new SaveData();
            return _save;
        }

        _save = JsonUtility.FromJson<SaveData>(save);
        return _save;
    }

    public override void Set(SaveData saveData)
    {
        _save = saveData;
    }

    public override void Save()
    {
        if (_save == null)
        {
            Debug.LogError("DefaultSaveController >> Save >> _save == null");
            return;
        }

        PlayerPrefs.SetString(KeySaveData, JsonUtility.ToJson(_save));
        PlayerPrefs.Save();
    }

    public void OnDestroy()
    {
        Save();
    }
}
