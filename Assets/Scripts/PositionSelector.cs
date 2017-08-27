using UnityEngine;

public class PositionSelector : MonoBehaviour
{
    public int PositionSelectorRange = 14;

    public int PositionSelectorStart = -7;
    public int PositionSelectorVelocity = 7;

    public int Velocity;
    public float Position = -7;

    void Update()
    {
        if (Velocity == 0)
        {
            return;
        }
        var delta = Velocity * Time.deltaTime;
        Position += delta;
        if (Position < 0 && Position < PositionSelectorStart)
        {
            Position = PositionSelectorStart;
            Velocity = PositionSelectorVelocity;
        }
        else if (Position > 0 && Position > PositionSelectorRange + PositionSelectorStart)
        {
            Position = PositionSelectorRange + PositionSelectorStart;
            Velocity = -PositionSelectorVelocity;
        }
        transform.position = new Vector3(transform.position.x, Position, transform.position.z);
    }

    public void StopMoving()
    {
        Velocity = 0;
    }

    public void SelectPosition()
    {
        Position = transform.position.y;
        Velocity = Position <= PositionSelectorStart ? PositionSelectorVelocity : -PositionSelectorVelocity;
    }
}