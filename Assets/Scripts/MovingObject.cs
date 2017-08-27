using System;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public abstract class MovingObject : MonoBehaviour
{
    protected Vector2 Position;
    protected int Velocity;
    protected int Direction;
    protected float Dh;
    protected float Dv;
    protected bool Force = false;
    protected bool MoveX = true;
    protected bool MoveY = true;

    public float RemainingDistance;

    private Movement2D _mvnt;

    private void Start()
    {
        _mvnt = gameObject.AddComponent<Movement2D>();
    }

    [SuppressMessage("ReSharper", "CompareOfFloatsByEqualityOperator")]
    protected void Update()
    {
        if (Velocity <= 0 || (Dh == 0 && Dv == 0))
        {
            return;
        }
        // Debug.Log("MO.Update" + Dh);

        var dx = MoveX ? Dh * Velocity * Time.deltaTime : 0;
        var dy = MoveY ? Dv * Velocity * Time.deltaTime : 0;
        var moved = false;
        if (Force)
        {
            moved = true;
            if (MoveX)
            {
                _mvnt.ForceMoveAlongX(dx);
            }
            if (MoveY)
            {
                _mvnt.ForceMoveAlongY(dy);
            }
        }
        else
        {
            if (MoveX)
            {
                moved = _mvnt.MoveAlongX(dx) || moved;
            }
            if (MoveY)
            {
                moved = _mvnt.MoveAlongY(dy) || moved;
            }
        }
        var distance = Mathf.Sqrt(dx * dx + dy * dy);
        RemainingDistance -= distance;
        if (RemainingDistance <= 0)
        {
            StopMoving();
        }
        OnMove(distance, moved);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Mvnt.SmoothGridMove(Vector2.right, Distance, false);
        }
    }

    protected virtual void OnMove(float distance, bool moved)
    {
        // override
    }

    public void MovingDirection(int direction)
    {
        Direction = direction;
        Dh = Mathf.Cos(direction * Mathf.PI / 180);
        Dv = Mathf.Sin(direction * Mathf.PI / 180);
    }

    public void MovingVelocity(int velocity)
    {
        Velocity = velocity;
    }

    public void StopMoving()
    {
        MovingVelocity(0);
    }

    public void MoveTo(Vector3 target)
    {
        _mvnt.Move(target);
    }
}