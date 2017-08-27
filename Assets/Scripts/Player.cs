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
    public GameObject DirectionLabel;
    public DirectionSelector DirectionSelector;


    public Player Init(Vector2 startingPosition, int index)
    {
        Debug.Log("Player.Init");

        _startingPosition = startingPosition;
        Index = index;
        GameObject positionSelectorObject = GameObject.Find("P" + Index + "PositionSelector");
        PositionSelector = positionSelectorObject.GetComponent<PositionSelector>();
        DirectionLabel = GameObject.Find("P" + Index + "DirectionLabel");
        GameObject directionSelectorObject = GameObject.Find("P" + Index + "DirectionSelector");
        DirectionSelector = directionSelectorObject.GetComponent<DirectionSelector>();
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
        AddHelicopter();
        CurrentHelicopter.gameObject.transform.position = new Vector3(CurrentHelicopter.gameObject.transform.position.x,
            PositionSelector.Position, CurrentHelicopter.gameObject.transform.position.z);
        CurrentHelicopter.Launch((int) DirectionSelector.Direction, 3);
    }

    public void SelectPosition()
    {
        PositionSelector.SelectPosition();
        PlayerState = State.Position;
    }

    public void PositionSelected()
    {
        PositionSelector.StopMoving();
        SelectDirection();
    }

    public void SelectDirection()
    {
        DirectionLabel.transform.position = new Vector3(DirectionLabel.transform.position.x,
            PositionSelector.Position, DirectionLabel.transform.position.z);
        DirectionSelector.gameObject.transform.position = new Vector3(DirectionSelector.gameObject.transform.position.x,
            PositionSelector.Position, DirectionSelector.gameObject.transform.position.z);
        DirectionSelector.SelectDirection();
        PlayerState = State.Direction;
    }

    public void DirectionSelected()
    {
        DirectionSelector.StopMoving();
        SelectDistance();
    }

    public void SelectDistance()
    {
        //DirectionSelector.SelectDirection();
        PlayerState = State.Distance;
    }

    public void DistanceSelected()
    {
        DirectionSelector.StopMoving();
        Launch();
    }
}