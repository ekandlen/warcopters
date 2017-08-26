using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<HelicopterModel> Helicopters = new List<HelicopterModel>();
    private Vector2 _startingPosition;

    public Player Init(Vector2 startingPosition)
    {
        Debug.Log("Player.Init");
        GameObject instance = Instantiate(GameManager.instance.Board.Helicopter,
            new Vector3(_startingPosition.x, _startingPosition.y, 0f), Quaternion.identity);
        HelicopterModel helicopter = instance.GetComponent<HelicopterModel>();
        helicopter.Init(startingPosition);
        instance.transform.SetParent(GameManager.instance.Board.Holder);

        _startingPosition = startingPosition;
        Helicopters.Add(helicopter);
        return this;
    }
}