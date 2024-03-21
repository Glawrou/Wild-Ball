using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class LocalizeController : MonoBehaviour
{
    [SerializeField] private SaveController _saveController;

    private Locale[] locales;
    private int _localeIndex = 0;

    private void Awake()
    {
        locales = LocalizationSettings.AvailableLocales.Locales.ToArray();
        var save = _saveController.Get();
        if (save.SettingsData.local != -1)
        {
            SetLocal(save.SettingsData.local);
        }

        _localeIndex = GetIndexLocale(LocalizationSettings.SelectedLocale);
    }

    public void SetLocal(string localName)
    {
        if (!locales.Any(l => l.LocaleName == localName))
        {
            Debug.LogError("LocalizeController >> SetLocal >> LocalName is not founded");
            return;
        }

        SetLocal(locales.FirstOrDefault(l => l.LocaleName == localName));
    }

    public void SetLocal(int index)
    {
        index = Mathf.Clamp(index, 0, locales.Length);
        SetLocal(locales[index]);
    }

    public void SwitchLanguage()
    {
        _localeIndex = _localeIndex + 1 >= LocalizationSettings.AvailableLocales.Locales.Count ? 0 : _localeIndex + 1;
        SetLocal(GetCurrentLocal());
    }

    private void SetLocal(Locale locale)
    {
        var save = _saveController.Get();
        save.SettingsData.local = GetIndexLocale(locale);
        LocalizationSettings.SelectedLocale = locale;
        _saveController.Set(save);
        _saveController.Save();
    }

    private int GetIndexLocale(Locale locale)
    {
        return Array.IndexOf(locales, locale);
    }

    private Locale GetCurrentLocal()
    {
        return locales[_localeIndex];
    }
}
