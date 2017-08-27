using System.Collections.Generic;
using System.IO;
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

    public float MaxHelicopterDistance = 2.5f;

    public List<HelicopterModel> Helicopters = new List<HelicopterModel>();
    public HelicopterModel CurrentHelicopter;
    public int Index;
    public State PlayerState = State.Waiting;
    private Vector2 _startingPosition;

    public PositionSelector PositionSelector;
    public GameObject DirectionLabel;
    public DirectionSelector DirectionSelector;
    public DistanceSelector DistanceSelector;


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
        GameObject distanceSelectorObject = GameObject.Find("P" + Index + "DistanceSelector");
        DistanceSelector = distanceSelectorObject.GetComponent<DistanceSelector>();
        return this;
    }

    public HelicopterModel AddHelicopter()
    {
        var source = GameManager.instance.Board.Stormcopter[Index - 1];
        GameObject instance = Instantiate(source,
            new Vector3(_startingPosition.x, _startingPosition.y, 0f), Quaternion.identity);
        HelicopterModel helicopter = instance.GetComponent<HelicopterModel>();
        helicopter.Init(_startingPosition);
        instance.transform.SetParent(GameManager.instance.Board.Holder);
        Helicopters.Add(helicopter);

        CurrentHelicopter = helicopter;
        return helicopter;
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
        DistanceSelector.SelectDistance();
        PlayerState = State.Distance;
    }

    public void DistanceSelected()
    {
        DistanceSelector.StopMoving();
        Launch();
    }

    public void Launch()
    {
        PlayerState = State.Waiting;
        AddHelicopter();
        CurrentHelicopter.gameObject.transform.position = new Vector3(CurrentHelicopter.gameObject.transform.position.x,
            PositionSelector.Position, CurrentHelicopter.gameObject.transform.position.z);
        var distance = Mathf.Abs(DistanceSelector.Distance) * MaxHelicopterDistance;

        CurrentHelicopter.Launch((int) DirectionSelector.Direction, distance);
    }
}