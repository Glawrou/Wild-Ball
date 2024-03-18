using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintTrigger : MonoBehaviour
{
    [SerializeField] private string HintName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != Player.PlayerTag)
        {
            return;
        }

        Hints.Open(HintName);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != Player.PlayerTag)
        {
            return;
        }

        Hints.Close(HintName);
    }
}
