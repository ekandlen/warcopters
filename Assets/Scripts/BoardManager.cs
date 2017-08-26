using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [HideInInspector] public Transform Holder;

    public GameObject Helicopter;
    private HelicopterModel _helicopter;

    public Field Field;

    public void Init()
    {
        Holder = new GameObject("BoardPanel").transform;
        Field = gameObject.AddComponent<Field>();
        Field.Init();
        //Invoke("MoveHelicopter", 1);
    }

    public void MoveHelicopter()
    {
        _helicopter.MovingVelocity(1);
        _helicopter.MovingDirection(45);
        Invoke("StopHelicopter", 3);
    }

    public void StopHelicopter()
    {
        _helicopter.MovingVelocity(0);
        _helicopter.MovingDirection(0);
    }
}