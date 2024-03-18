using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishingPlatform : LevelItem
{
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == Player.PlayerTag)
        {
            gameObject.SetActive(false);
        }
    }
}
