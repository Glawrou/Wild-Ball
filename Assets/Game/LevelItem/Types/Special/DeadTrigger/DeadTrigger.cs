using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _deadEffect;

    private const float DelayDead = 10f;

    private void OnTriggerEnter(Collider other)
    {
        SpawnDeadEffect(other.transform.position);
        if (other.gameObject.tag == Player.PlayerTag)
        {
            other.GetComponent<Player>().Dead();
            return;
        }

        Destroy(other.gameObject);
    }

    public void SpawnDeadEffect(Vector3 position)
    {
        var effect = Instantiate(_deadEffect, position, Quaternion.identity, null);
        Destroy(effect, DelayDead);
    }
}
