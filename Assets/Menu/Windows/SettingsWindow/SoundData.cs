using UnityEngine;

public class SoundData
{
    public string Key { get; private set; }
    public int ValueInt { get; private set; }
    public float Value { get; private set; }

    public const int MinValue = -80;

    public SoundData(string key, float value)
    {
        Key = key;
        Value = Mathf.Clamp(value, 0, 1);
        ValueInt = Mathf.RoundToInt((1f - Value) * MinValue);
    }
}
