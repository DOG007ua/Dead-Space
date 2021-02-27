using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnUnitsArray", menuName = "ScriptableObjects/SpawnUnitsArray", order = 1)]
public class SpawnManagerScriptableObject : ScriptableObject
{
    public List<BuildUnit> units = new List<BuildUnit>();
}
