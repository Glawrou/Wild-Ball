using System.Linq;
using UnityEngine;

public class Hints : MonoBehaviour
{
    [SerializeField] private WindowHint[] _hintsStorage;

    private static WindowHint[] _hints;

    private void Awake()
    {
        _hints = _hintsStorage;
    }

    public static void Open(string key)
    {
        var hint = FindHint(key);
        if (hint == null)
        {
            return;
        }

        hint.Open();
    }

    public static void Close(string key)
    {
        var hint = FindHint(key);
        if (hint == null)
        {
            return;
        }

        hint.Close();
    }

    private static WindowHint FindHint(string key)
    {
        if (!_hints.Any(w => w.HitName == key))
        {
            Debug.LogError("Hints >> FindHint >> NotFind");
            return null;
        }

        return _hints.FirstOrDefault(w => w.HitName == key);
    }
}
