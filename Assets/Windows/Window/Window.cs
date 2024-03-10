using UnityEngine;

public class Window : MonoBehaviour
{
    public string WindowName { get; protected set; }

    [SerializeField] protected BackgroundWindow _backgroundWindow;
    [SerializeField] private ViewWindow _viewWindow;

    public void Open()
    {
        _viewWindow.Open();
        _backgroundWindow.Open();
    }

    public void Close()
    {
        _viewWindow.Close();
        _backgroundWindow.Close();
    }
}
