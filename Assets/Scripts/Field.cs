using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    public static int BOARD_WIDTH = 16;
    public static int BOARD_HEIGHT = 9;

    public List<Player> Players = new List<Player>();
    private List<Vector2> _startingPositions = new List<Vector2>();

    public Field Init()
    {
        Debug.Log("Field.Init()");
        _startingPositions.Add(new Vector2(-BOARD_WIDTH + 1, 0));
        _startingPositions.Add(new Vector2(BOARD_WIDTH - 1, 0));

        foreach (var startingPosition in _startingPositions)
        {
            Players.Add(gameObject.AddComponent<Player>().Init(startingPosition));
        }
        return this;
    }
}