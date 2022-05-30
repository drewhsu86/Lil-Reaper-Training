using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnTroopScriptable", order = 1)]
public class SpawnTroopScriptable : ScriptableObject
{
    public int timeToSpawn;
    public List<int> spawnList;
    public int numberToSpawn;
}
