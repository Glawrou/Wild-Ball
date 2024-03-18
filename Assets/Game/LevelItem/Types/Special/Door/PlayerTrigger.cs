using System;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public event Action<Player> OnPlayerEnter;
    public event Action<Player> OnPlayerExit;

    private void OnTriggerEnter(Collider other)
    {
        TriggerHandler(other, OnPlayerEnter);
    }

    private void OnTriggerExit(Collider other)
    {
        TriggerHandler(other, OnPlayerExit);
    }

    private void TriggerHandler(Collider other, Action<Player> action)
    {
        if (other.gameObject.tag != Player.PlayerTag)
        {
            return;
        }

        action?.Invoke(other.GetComponent<Player>());
    }
}
