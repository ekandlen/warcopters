using UnityEngine;

public class Util
{
    public static Vector3 toDisplay(Vector2 coords)
    {
        return new Vector3(coords.x, coords.y, 0);
    }
}