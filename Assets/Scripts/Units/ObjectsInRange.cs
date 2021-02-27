using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectsInRange : MonoBehaviour
{
    public float range;
    public List<UnitBehvarion> listObject = new List<UnitBehvarion>();
    string[] massTag;
    public event Action<UnitBehvarion> eventAddObjectInRange;
    public event Action<UnitBehvarion> eventRemoveObjectInRange;


    private void Start()
    { 
        range = 20;
        GetComponent<SphereCollider>().radius = range;
        massTag = new string[2] { "BlueTeam", "Enemy" };        
    }

    public void AddObject(GameObject obj)
    {
        var unit = obj.GetComponent<UnitBehvarion>();
        unit.deadUnit += DeadUnitInList;
        listObject.Add(unit);
        eventAddObjectInRange?.Invoke(unit);
    }

    public void RemoveObject(GameObject obj)
    {
        var unit = obj.GetComponent<UnitBehvarion>();
        unit.deadUnit -= DeadUnitInList;
        listObject.Remove(unit);
        eventRemoveObjectInRange?.Invoke(unit);
    }

    void DeadUnitInList(UnitBehvarion unit)
    {
        RemoveObject(unit.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        var obj = other.gameObject;
        var massString = massTag.FirstOrDefault(v => obj.tag == v);

        if(massString != null)
        {
            AddObject(obj);
            Debug.Log("Add" + other.name);
        }        
    }   

    private void OnTriggerExit(Collider other)
    {
        var obj = other.gameObject;
        var massString = massTag.FirstOrDefault(v => obj.tag == v);
        if (massString != null)
        {
            RemoveObject(obj);
            Debug.Log("Exit" + other.name);
        }
    }

    private void OnDestroy()
    {
        foreach(var unit in listObject)
        {
            unit.deadUnit -= DeadUnitInList;
        }
    }
}
