using UnityEngine;

public class HelicopterModel : MovingObject
{
    public static int HELICOPTER_DEFAULT_VELOCITY = 4;
    public int MaxHP = 100;
    public int HP;

    public Vector2 StartingPosition = new Vector2(0, 0);

    public HelicopterModel()
    {
        HP = MaxHP;
        Velocity = HELICOPTER_DEFAULT_VELOCITY;
    }

    public HelicopterModel Init(Vector2 startingPosition)
    {
        StartingPosition = startingPosition;
        Position = new Vector2(StartingPosition.x, StartingPosition.y);
        gameObject.transform.position = new Vector3(StartingPosition.x, StartingPosition.y);
        return this;
    }

    public void Launch(int direction, float distance)
    {
        if (RemainingDistance > 0)
        {
            RemainingDistance += distance;
        }
        else
        {
            RemainingDistance = distance;
        }
        MovingDirection(direction);
        MovingVelocity(HELICOPTER_DEFAULT_VELOCITY);
    }
}