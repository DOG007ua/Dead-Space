using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beiling : UnitBehvarion
{
    void Start()
    {
        Initialization(this.gameObject, new string[] { "BlueTeam" });
        HP = 100;
        controllerMove.Speed = 3;
        controllerMove.PositionMove = transform.position;
        canSelect = false;
    }

    void Update()
    {
        Execute();
        MoveToTarget();
        DeleteBeiling();
    }

    public void DeleteBeiling()
    {
        if (Target == null) return;

        var distance = Vector3.Distance(transform.position, Target.transform.position);
        if(distance < 0.3)
        {
            Target.Damage(30);
            //Destroy(Target.gameObject);
            Destroy(this.gameObject);
        }
    }

    private void MoveToTarget()
    {
        if(Target != null)
        {
            controllerMove.PositionMove = Target.transform.position;
        }
    }
}
