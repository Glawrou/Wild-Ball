using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadTrigger : MonoBehaviour
{
    public event Action OnDead;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        if (other.gameObject.tag != Player.PlayerTag)
        {
            return;
        }

        OnDead?.Invoke();
    }
}
