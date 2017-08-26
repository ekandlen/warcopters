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

    private Movement2D _mvnt;

    private void Start()
    {
        _mvnt = gameObject.AddComponent<Movement2D>();
    }

    [SuppressMessage("ReSharper", "CompareOfFloatsByEqualityOperator")]
    private void Update()
    {
        if (Velocity <= 0 || (Dh == 0 && Dv == 0))
        {
            return;
        }
        // Debug.Log("MO.Update" + Dh);

        _mvnt.MoveAlongX(Dh * Velocity * Time.deltaTime);
        _mvnt.MoveAlongY(Dv * Velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Mvnt.SmoothGridMove(Vector2.right, Distance, false);
        }
    }

    protected virtual void OnMove(float distance)
    {
        // override
    }

    public void MovingDirection(int direction)
    {
        Direction = direction;
        Dh = Mathf.Sin(direction * Mathf.PI / 180);
        Dv = Mathf.Cos(direction * Mathf.PI / 180);
        Debug.Log("MO.direction " + gameObject.transform.position);
    }

    public void MovingVelocity(int velocity)
    {
        Velocity = velocity;
    }
}