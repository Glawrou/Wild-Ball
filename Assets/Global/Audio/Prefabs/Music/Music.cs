using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private static Music _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        _audioSource.Play();
        DontDestroyOnLoad(gameObject);
    }
}
