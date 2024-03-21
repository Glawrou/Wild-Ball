using System;

[Serializable]
public class SaveData
{
    public SettingsData SettingsData;
    public PlayerProgressData PlayerProgressData;

    public SaveData()
    {
        SettingsData = new SettingsData();
        PlayerProgressData = new PlayerProgressData();
    }
}
