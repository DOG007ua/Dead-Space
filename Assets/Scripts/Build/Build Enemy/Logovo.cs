using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class Logovo : Build
{
   

    void Start()
    {
        Initialized(this.gameObject);
        eventSpawnUnit += AddMove;
    }

    // Update is called once per frame
    void Update()
    {
        Execute();
        if(isSpawn == false)
        {
            StartSpawn(unitsBuild.units[0].typeUnit);
        }
    }

    void AddMove(GameObject go)
    {
        UnitBehvarion lastUnit = go.GetComponent<UnitBehvarion>();
        lastUnit.PositionMove = new Vector3(0, 0.5f, 0);
    }
}
