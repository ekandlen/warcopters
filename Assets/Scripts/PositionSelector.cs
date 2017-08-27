using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSelector : SelectorBase
{
    public static int POSITION_SELECTOR_RANGE = 16;
    public static int POSITION_SELECTOR_START = -8;
    public static int POSITION_SELECTOR_SPEED = 3;

    public static int DIRECTION_UP = -90;
    public static int DIRECTION_DOWN = 90;

    public float CurrentPosition;

    public PositionSelector()
    {
        Force = true;
        MoveX = false;
    }

    public void SelectPosition()
    {
        MovingDirection(DIRECTION_UP);
        MovingVelocity(POSITION_SELECTOR_SPEED);

        CurrentPosition = gameObject.transform.position.y;
        RemainingDistance = POSITION_SELECTOR_RANGE;
    }

    protected override void OnMove(float distance, bool moved)
    {
        CurrentPosition = gameObject.transform.position.y;
        if (CurrentPosition < POSITION_SELECTOR_START)
        {
            MovingDirection(DIRECTION_UP);
            RemainingDistance = POSITION_SELECTOR_RANGE;
            MovingVelocity(POSITION_SELECTOR_SPEED);
        }
        else if (CurrentPosition > POSITION_SELECTOR_START + POSITION_SELECTOR_RANGE)
        {
            MovingDirection(DIRECTION_DOWN);
            RemainingDistance = POSITION_SELECTOR_RANGE;
            MovingVelocity(POSITION_SELECTOR_SPEED);
        }
    }
}