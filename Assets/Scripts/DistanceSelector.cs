using UnityEngine;

public class DistanceSelector : MonoBehaviour
{
    public float DistanceSelectorRange = 2;

    public float DistanceSelectorStart = 0.8f;
    public float DistanceSelectorVelocity = 1;

    public float Velocity;
    public float Distance = 0.2f;

    // Update is called once per frame
    void Update()
    {
        if (Velocity == 0)
        {
            return;
        }
        var delta = Velocity * Time.deltaTime;
        Distance += delta;
        if (DistanceSelectorRange < 0) // inverted for second player
        {
            if (Distance <= DistanceSelectorStart)
            {
                Distance = DistanceSelectorStart;
                Velocity = DistanceSelectorVelocity;
            }
            else if (Distance > -DistanceSelectorRange)
            {
                Distance = -DistanceSelectorRange;
                Velocity = -DistanceSelectorVelocity;
            }
            transform.localPosition = new Vector3(-Distance, transform.localPosition.y, transform.localPosition.z);
        }
        else
        {
            if (Distance <= DistanceSelectorStart)
            {
                Distance = DistanceSelectorStart;
                Velocity = DistanceSelectorVelocity;
            }
            else if (Distance > DistanceSelectorRange)
            {
                Distance = DistanceSelectorRange;
                Velocity = -DistanceSelectorVelocity;
            }
            transform.localPosition = new Vector3(Distance, transform.localPosition.y, transform.localPosition.z);
        }
    }

    public void StopMoving()
    {
        Velocity = 0;
    }

    public void SelectDistance()
    {
        Velocity = Distance <= DistanceSelectorStart ? DistanceSelectorVelocity : -DistanceSelectorVelocity;
    }
}