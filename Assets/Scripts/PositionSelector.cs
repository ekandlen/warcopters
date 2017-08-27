using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSelector : SelectorBase
{
    public static int POSITION_SELECTOR_RANGE = 16;
    public static int POSITION_SELECTOR_START = -8;
    public static int POSITION_SELECTOR_SPEED = 3;

    public int CurrentPosition;

    public void SelectPosition()
    {
        //MoveTo();
        //PositionSelector.transform.position.y = POSITION_SELECTOR_START;
    }
}