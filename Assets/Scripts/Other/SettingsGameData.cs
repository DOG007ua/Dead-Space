using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SettingsGameplay", order = 3)]
public class SettingsGameData : ScriptableObject
{
    public Color colorBlueTeam;
    public Material transperentMaterial;
}
