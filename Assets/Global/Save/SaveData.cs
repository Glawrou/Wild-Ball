using System;

[Serializable]
public class SaveData
{
    public SettingsData SettingsData;

    public SaveData()
    {
        SettingsData = new SettingsData();
    }
}
