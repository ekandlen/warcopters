using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<HelicopterModel> Helicopters = new List<HelicopterModel>();
    public HelicopterModel CurrentHelicopter;
    public int Index;
    private Vector2 _startingPosition;

    public PositionSelector PositionSelector;


    public Player Init(Vector2 startingPosition, int index)
    {
        Debug.Log("Player.Init");

        _startingPosition = startingPosition;
        Index = index;
        AddHelicopter();
        return this;
    }

    private void Start()
    {
        GameObject positionSelectorObject = GameObject.Find("P" + Index + "PositionSelector");
        PositionSelector = positionSelectorObject.GetComponent<PositionSelector>();
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
    }
}