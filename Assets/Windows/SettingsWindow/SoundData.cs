using UnityEngine;

public class SoundData
{
    public string Key { get; private set; }
    public int Value { get; private set; }

    private const int MinValue = -80;

    public SoundData(string key, float value)
    {
        Key = key;
        Value = Mathf.RoundToInt((float)MinValue * (1 - Mathf.Clamp(value, 0, 1)));
    }
}
