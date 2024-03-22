using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _deadEffect;
    [SerializeField] private bool IsOnlyPlayer = false;

    private const float DelayDead = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Player.PlayerTag)
        {
            SpawnDeadEffect(other.transform.position);
            other.GetComponent<Player>().Dead();
            return;
        }

        if (IsOnlyPlayer)
        {
            return;
        }

        SpawnDeadEffect(other.transform.position);
        Destroy(other.gameObject);
    }

    public void SpawnDeadEffect(Vector3 position)
    {
        var effect = Instantiate(_deadEffect, position, Quaternion.identity, null);
        Destroy(effect, DelayDead);
    }
}
