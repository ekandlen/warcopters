using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum State
    {
        // waiting for my turn
        Waiting,

        // selecting position
        Position,

        // selecting direction
        Direction,

        // selecting distance
        Distance,

        // moving
        Moving
    }

    public List<HelicopterModel> Helicopters = new List<HelicopterModel>();
    public HelicopterModel CurrentHelicopter;
    public int Index;
    public State PlayerState = State.Waiting;
    private Vector2 _startingPosition;

    public PositionSelector PositionSelector;


    public Player Init(Vector2 startingPosition, int index)
    {
        Debug.Log("Player.Init");

        _startingPosition = startingPosition;
        Index = index;
        GameObject positionSelectorObject = GameObject.Find("P" + Index + "PositionSelector");
        PositionSelector = positionSelectorObject.GetComponent<PositionSelector>();
        return this;
    }

    public HelicopterModel AddHelicopter()
    {
        GameObject instance = Instantiate(GameManager.instance.Board.Helicopter,
            new Vector3(_startingPosition.x, _startingPosition.y, 0f), Quaternion.identity);
        HelicopterModel helicopter = instance.GetComponent<HelicopterModel>();
        helicopter.Init(_startingPosition);
        instance.transform.SetParent(GameManager.instance.Board.Holder);
        Helicopters.Add(helicopter);

        CurrentHelicopter = helicopter;
        return helicopter;
    }

    public void Launch()
    {
        CurrentHelicopter.Launch(45, 3);
    }

    public void SelectPosition()
    {
        PositionSelector.SelectPosition();
        PlayerState = State.Position;
    }

    public void PositionSelected()
    {
        PositionSelector.StopMoving();
        PlayerState = State.Direction;
        AddHelicopter();
        CurrentHelicopter.gameObject.transform.position = new Vector3(CurrentHelicopter.gameObject.transform.position.x,
            PositionSelector.CurrentPosition, CurrentHelicopter.gameObject.transform.position.z);
        
    }
}