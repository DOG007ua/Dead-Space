using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnUnit", menuName = "ScriptableObjects/SpawnUnit", order = 1)]
public class BuildUnit : ScriptableObject
{
    public string Name;
    public GameObject Prefab;
    public float TimeSpawn;
    public EnemyUnitsType typeUnit;
}

