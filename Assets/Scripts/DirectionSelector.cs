using UnityEngine;

public class DirectionSelector : MonoBehaviour
{
    // degree
    public int DirectionSelectorRange = 180;

    public int DirectionSelectorStart = -90;
    public int DirectionSelectorVelocity = 90;

    public int Velocity;
    public float Direction;
    private float _directionOffset;

    // Update is called once per frame
    void Update()
    {
        if (Velocity == 0)
        {
            return;
        }
        var delta = Velocity * Time.deltaTime;
        _directionOffset += delta;
        if (_directionOffset <= 0)
        {
            _directionOffset = 0;
            Velocity = DirectionSelectorVelocity;
        }
        else if (_directionOffset >= DirectionSelectorRange)
        {
            _directionOffset = DirectionSelectorRange;
            Velocity = -DirectionSelectorVelocity;
        }
        Direction = DirectionSelectorStart + _directionOffset;
        gameObject.transform.rotation = Quaternion.AngleAxis(Direction, Vector3.forward);
    }

    public void StopMoving()
    {
        Velocity = 0;
    }

    public void SelectDirection()
    {
        _directionOffset = Direction - DirectionSelectorStart;
        Velocity = Direction <= DirectionSelectorStart ? DirectionSelectorVelocity : -DirectionSelectorVelocity;
    }
}