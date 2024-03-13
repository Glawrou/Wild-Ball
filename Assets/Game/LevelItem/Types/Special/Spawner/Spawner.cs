using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Rigidbody _spawnObject;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _startForce = 200;

    [Header("Behavior")]
    [SerializeField] private bool _autoSpawn = false;
    [SerializeField] private float _delayAutoSpawn = 5f;

    private void Start()
    {
        StartCoroutine(AutoSpawn());
    }

    [ContextMenu("Spawn")]
    public void Spawn()
    {
        var obj = Instantiate(_spawnObject, _spawnPoint.position, Quaternion.identity, null);
        obj.AddForce(-transform.right * _startForce * obj.mass);
    }

    private IEnumerator AutoSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(_delayAutoSpawn);
            if (!_autoSpawn)
            {
                continue;
            }

            Spawn();
        }
    }
}
