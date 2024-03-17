using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private readonly Vector3 StartRotate = new Vector3(0, -90, 0);

    public Player Spawn(Player playerPrefab)
    {
        return Instantiate(playerPrefab, transform.position, Quaternion.Euler(StartRotate), null);
    }
}
