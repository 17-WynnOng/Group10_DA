using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject normalenemy;
    public GameObject heavyenemy;
    public GameObject fastenemy;

    public float normalspawnInterval;
    public float heavyspawnInterval;
    public float fastspawnInterval;

    private float SpawnZone;
    private float timer;
    public int SpawnAmount;
    public float SpawnerLeftBorder;
    public float SpawnerRightBorder;
    // Start is called before the first frame update
    void Start()
    {
        SpawnAmount = GameManager.Instance.EnemiesInWave;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

       if (timer > normalspawnInterval)
       {
            NormalSpawn();

            timer = 0;
       }

       if (timer > heavyspawnInterval)
       {


       }
    }

    public void NormalSpawn()
    {
        if (SpawnAmount > 0)
        {
            SpawnAmount--;

            SpawnZone = Random.Range(SpawnerLeftBorder, SpawnerRightBorder);
            Vector3 RandomSpawn = new Vector3(SpawnZone, transform.position.y, transform.position.z);

            Instantiate(normalenemy, RandomSpawn, Quaternion.Euler(0, 180, 0));
        }
    }

    public void HeavySpawn()
    {
        if (SpawnAmount > 0)
        {
            SpawnAmount--;

            SpawnZone = Random.Range(SpawnerLeftBorder, SpawnerRightBorder);
            Vector3 RandomSpawn = new Vector3(SpawnZone, transform.position.y, transform.position.z);

            Instantiate(heavyenemy, RandomSpawn, Quaternion.Euler(0, 180, 0));
        }
    }

    public void FastSpawn()
    {
        if (SpawnAmount > 0)
        {
            SpawnAmount--;

            SpawnZone = Random.Range(SpawnerLeftBorder, SpawnerRightBorder);
            Vector3 RandomSpawn = new Vector3(SpawnZone, transform.position.y, transform.position.z);

            Instantiate(fastenemy, RandomSpawn, Quaternion.Euler(0, 180, 0));
        }
    }
}
