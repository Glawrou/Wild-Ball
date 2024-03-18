using System.Collections;
using UnityEngine;

public class WindowHint : MonoBehaviour
{
    [field: SerializeField] public string HitName { get; private set; }

    [SerializeField] private ViewWindow _viewWindow;

    public void Open()
    {
        _viewWindow.Open();
    }

    public void Close(float delay)
    {
        StartCoroutine(CloseProcess(delay));
    }

    public void Close()
    {
        _viewWindow.Close();
    }

    private IEnumerator CloseProcess(float delay)
    {
        yield return new WaitForSeconds(delay);
        Close();
    }
}
