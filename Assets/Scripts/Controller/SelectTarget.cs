using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class SelectTarget
{
    private UnitBehvarion target;
    public UnitBehvarion Target 
    {
        get => target;
        set
        {
            target = value;
            newTarget?.Invoke(value);
        }
    }
    GameObject gameObject;
    List<UnitBehvarion> listObjInRange;
    string[] massTagTarget;
    public Action<UnitBehvarion> newTarget;

    public SelectTarget(List<UnitBehvarion> listObjInRange, string[] massTagTarget, GameObject gameObject)
    {
        this.listObjInRange = listObjInRange;
        this.gameObject = gameObject;
        this.massTagTarget = massTagTarget;        
    }

    public void Execute()
    {

    }

    public void AddObjectInRange(UnitBehvarion obj)
    {
        SetTarget();
    }

    public void RemoveObjectInRange(UnitBehvarion obj)
    {
        RemoveTargetInList(obj);
    }

    public void SetTarget()
    {
        if (Target != null) return;

        var minDistance = 100000.0;
        UnitBehvarion targetMinDistance = null;
        var listNeedTarget = from tag in massTagTarget
                             from obj in listObjInRange
                             where obj.gameObject.tag == tag
                             select obj;

        foreach (var v in listNeedTarget)
        {
            var dist = Vector3.Distance(gameObject.transform.position, v.transform.position);
            if (dist < minDistance)
            {
                minDistance = dist;
                targetMinDistance = v;
            }
        }

        Target = targetMinDistance;
    }

    void RemoveTargetInList(UnitBehvarion obj)
    {
        if (obj != Target) return;

        Target = null;
        SetTarget();
    }
}
