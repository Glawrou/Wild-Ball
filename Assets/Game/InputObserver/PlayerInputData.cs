using UnityEngine;

public class PlayerInputData
{
    public Vector2 Move { get; private set; }
    public bool Jump { get; private set; }
    public bool Use { get; private set; }

    public PlayerInputData(float x, float y, bool jump, bool use)
    {
        Move = new Vector2(x, y).normalized;
        Jump = jump;
        Use = use;
    }
}