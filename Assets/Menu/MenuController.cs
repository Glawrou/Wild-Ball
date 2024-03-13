using UnityEngine;

public class MenuController : SceneController
{
    [SerializeField] private Windows _windows;

    [Header("Windows")]
    [SerializeField] private MenuWindow _menuWindow;
    [SerializeField] private SelectWindow _selectWindow;
    [SerializeField] private SettingsWindow _settingsWindow;

    private void Start()
    {
        InitWindows();
        InitMenuWindow();
        InitSelectWindow();
        InitSettingsWindow();
    }

    private void InitWindows()
    {
        _windows.Init(new Window[] { _menuWindow, _selectWindow, _settingsWindow });
    }

    private void InitMenuWindow()
    {
        _menuWindow.OnPressPlay += OpenSelectWindow;
        _menuWindow.OnPressSettings += () => _windows.Open("Settings");
        _menuWindow.OnPressExit += ApplicationExit;
    }

    private void InitSelectWindow()
    {
        _selectWindow.OnBack += OpenMenuWindow;
        _selectWindow.OnLevelPress += LoadLevel;
    }

    private void InitSettingsWindow()
    {
        _settingsWindow.OnBack += OpenMenuWindow;
        _settingsWindow.OnSelectSoundData += SetAudioMixer;
        _settingsWindow.OnClearData += ClearSave;
        _settingsWindow.SetValueAudioMixer(
            GetValueAudioMixer(SettingsData.KeyMixerMaster), 
            GetValueAudioMixer(SettingsData.KeyMixerSound), 
            GetValueAudioMixer(SettingsData.KeyMixerMusic));
    }

    private void OpenMenuWindow()
    {
        _windows.Open(_menuWindow.WindowName);
    }

    private void OpenSelectWindow()
    {
        _windows.Open(_selectWindow.WindowName);
    }

    public void LoadLevel(int level)
    {
        LoadScene(new GameSceneParams(level));
    }
}
