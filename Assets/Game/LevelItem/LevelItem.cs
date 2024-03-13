using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class LevelItem : MonoBehaviour
{
    private void Update()
    {
        transform.position = Round(transform.position);
    }

    private Vector3 Round(Vector3 vector)
    {
        return new Vector3(Round(vector.x), Round(vector.y), Round(vector.z));
    }

    private float Round(float value)
    {
        return Mathf.Round(value);
    }
}
