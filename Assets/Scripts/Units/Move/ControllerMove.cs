using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMove
{
    private Transform transform;
    public float Speed;
    public bool NeedMove { get; protected set; }
    private Vector3 positionMove;
    public UnitBehvarion Target
    {
        get => selectTarget.Target;
        set => selectTarget.Target = value;
    }
    SelectTarget selectTarget;

    public Vector3 PositionMove
    {
        get { return positionMove; }
        set
        {
            positionMove = value;
            transform.LookAt(value);
            NeedMove = true;
        }
    }

    public ControllerMove(Transform transform, SelectTarget selectTarget)
    {
        this.selectTarget = selectTarget;
        this.transform = transform;
    }

    public void Execute()
    {
        LookAtTarget();
        Move();
    }

    public void LookAtTarget()
    {
        if (Target != null && !NeedMove) transform.LookAt(Target.transform);
    }

    protected void DeletePositionMove()
    {
        NeedMove = false;
    }

    protected void Move()
    {
        if (NeedMove)
        {
            transform.position += transform.forward * Speed * Time.deltaTime;
            var distance = Vector3.Distance(transform.position, positionMove);
            if (distance < 0.1f)
            {
                DeletePositionMove();
            }
        }
    }
}
