using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    public static int BOARD_WIDTH = 16;
    public static int BOARD_HEIGHT = 9;

    public List<Player> Players = new List<Player>();
    public Player CurrentPlayer;
    private List<Vector2> _startingPositions = new List<Vector2>();

    public Field Init()
    {
        Debug.Log("Field.Init()");
        _startingPositions.Add(new Vector2(-BOARD_WIDTH + 2, 0));
        _startingPositions.Add(new Vector2(BOARD_WIDTH - 2, 0));

        Players.Add(gameObject.AddComponent<Player>().Init(_startingPositions[0], 1));
        Players.Add(gameObject.AddComponent<Player>().Init(_startingPositions[1], 2));

        CurrentPlayer = Player1();
        return this;
    }

    public Player Player1()
    {
        return Players[0];
    }

    public Player Player2()
    {
        return Players[1];
    }

    public void Launch(Player player)
    {
        if (player.PlayerState == Player.State.Position)
        {
            player.PositionSelected();
        }
        else if (player.PlayerState == Player.State.Direction)
        {
            player.DirectionSelected();
        }
        else if (player.PlayerState == Player.State.Distance)
        {
            player.DistanceSelected();
        }
        else if(player.PlayerState == Player.State.Moving)
        {
            // ignore
        }
    }

    private void Start()
    {
        CurrentPlayer.SelectPosition();

        //if (Input.GetKeyDown(KeyCode.Return))
    }

    public void NextPlayerMove()
    {
        CurrentPlayer.PositionSelector.StopMoving();
    }
}