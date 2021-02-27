using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Build : MonoBehaviour
{
    public SpawnManagerScriptableObject unitsBuild;
    private Vector3 positionSpawn;
    private GameObject gameObject;
    public float timeLeft;
    public bool isSpawn;
    BuildUnit unitSpawnNow;
    public Action<GameObject> eventSpawnUnit;

    private BuildUnit UnitSpawnNow
    {
        get { return unitSpawnNow; }
        set
        {
            unitSpawnNow = value;
            timeLeft = value.TimeSpawn;
        }
    }

    public void Initialized(GameObject gameObject)
    {
        timeLeft = 0;
        this.gameObject = gameObject;
        positionSpawn = gameObject.transform.Find("SpawnPoint").position;
        if (positionSpawn == null) Debug.Log($"Нет точки спавна для {gameObject.name}");
    }

    public void Execute()
    {
        TimerSpawn();
    }

    public void StartSpawn(EnemyUnitsType typeUnit)
    {
        var unit = unitsBuild.units.FirstOrDefault(v => v.typeUnit == typeUnit);
        if(unit != null)
        {
            isSpawn = true;
            UnitSpawnNow = unit;
        }
        else
        {
            Debug.Log("Нет такого юнита в постройке");
        }
    }

    public void SpawnUnit(BuildUnit unit)
    {
        if (positionSpawn == null)
        {
            if (positionSpawn == null) Debug.Log($"Нет точки спавна для {gameObject.name}");
            return;
        }

        var goUnit = Instantiate(unit.Prefab);
        goUnit.transform.position = positionSpawn;
        eventSpawnUnit?.Invoke(goUnit);
    }

    private void TimerSpawn()
    {
        if(isSpawn)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                SpawnUnit(unitSpawnNow);
                isSpawn = false;
            }
        }
    }

}
