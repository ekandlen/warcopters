using UnityEngine;

public class DirectionSelector : MonoBehaviour
{
    // degree
    public int DirectionSelectorRange = 180;

    public int DirectionSelectorStart = -90;
    public int DirectionSelectorVelocity = 90;

    public int Velocity;
    public float Direction = -90;

    // Update is called once per frame
    void Update()
    {
        if (Velocity == 0)
        {
            return;
        }
        var delta = Velocity * Time.deltaTime;
        Direction += delta;
        if (Direction < 0 && Direction < DirectionSelectorStart)
        {
            Direction = DirectionSelectorStart;
            Velocity = DirectionSelectorVelocity;
        }
        else if (Direction > 0 && Direction > DirectionSelectorRange + DirectionSelectorStart)
        {
            Direction = DirectionSelectorRange + DirectionSelectorStart;
            Velocity = -DirectionSelectorVelocity;
        }
        gameObject.transform.rotation = Quaternion.AngleAxis(Direction, Vector3.forward);
    }

    public void StopMoving()
    {
        Velocity = 0;
    }

    public void SelectDirection()
    {
        Velocity = Direction <= DirectionSelectorStart ? DirectionSelectorVelocity : -DirectionSelectorVelocity;
    }
}