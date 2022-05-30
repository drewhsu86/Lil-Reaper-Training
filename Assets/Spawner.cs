using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] List<SpawnTroopScriptable> spawnList;
    [SerializeField] List<GameObject> spawnRef;
    [SerializeField] float distFromCenter = 11f;
    private int currentSpawn = 0;
    
    public void CheckEachSecond(int elapsedSeconds) {
        if (currentSpawn < spawnList.Count && spawnList[currentSpawn].timeToSpawn == elapsedSeconds) {
            Spawn(spawnList[currentSpawn]);
            currentSpawn += 1;
        }
    }

    private void Spawn(SpawnTroopScriptable spawn) {
        for (int i = 0; i < spawn.numberToSpawn; i++) {
            // pick a spot using a random angle and radius
            float angleInRadians = Random.Range(0f, 2 * Mathf.PI);
            float spawnX = distFromCenter * Mathf.Cos(angleInRadians);
            float spawnY = distFromCenter * Mathf.Sin(angleInRadians);
            
            // pick a random value from spawn.spawnList
            int randInd = Random.Range(0, spawn.spawnList.Count);
            GameObject spawnObj = spawnRef[spawn.spawnList[randInd]];

            // spawn this Obj
            GameObject thisSpawn = Instantiate(spawnObj, new Vector3(spawnX, spawnY, 0), Quaternion.identity);
        }
    }
}
