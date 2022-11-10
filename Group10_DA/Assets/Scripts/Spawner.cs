using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    private float SpawnZone;
    public float spawnDelay;
    public float spawnTime;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    public void Spawn()
    {
        SpawnZone = Random.Range(-7.5f, 20f);
        Vector3 RandomSpawn = new Vector3(SpawnZone, transform.position.y, transform.position.z);

        Instantiate(enemy, RandomSpawn, Quaternion.Euler(0, 180, 0));
    }
}
