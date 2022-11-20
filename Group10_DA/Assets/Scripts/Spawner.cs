using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject normalenemy;
    public GameObject heavyenemy;

    public float normalspawnInterval;
    public float heavyspawnInterval;

    private float SpawnZone;
    private float timer;


    public int SpawnAmount;
    public float SpawnerLeftBorder;
    public float SpawnerRightBorder;

    // Start is called before the first frame update
    void Start()
    {
        SpawnAmount = GameManager.Instance.EnemiesInWave;

        StartCoroutine(NormalSpawn());


        StartCoroutine(HeavySpawn());
        
        
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public IEnumerator NormalSpawn()
    {
        yield return new WaitForSeconds(normalspawnInterval);

        if (SpawnAmount > 0)
        {
            SpawnAmount--;
            SpawnZone = Random.Range(SpawnerLeftBorder, SpawnerRightBorder);
            
            if(GameManager.Instance.DifficultyIncrement >= 2)
            {
                normalenemy.GetComponent<EnemyScript>().health += 2;
                normalenemy.GetComponent<EnemyScript>().speed += 1;
                normalenemy.GetComponent<EnemyScript>().DamageAmount += 1;

                GameManager.Instance.DifficultyIncrement = 0;
            }
            
            Vector3 RandomSpawn = new Vector3(SpawnZone, transform.position.y, transform.position.z);
            Instantiate(normalenemy, RandomSpawn, Quaternion.Euler(0, 180, 0));

            StartCoroutine(NormalSpawn());
        }
    }

    public IEnumerator HeavySpawn()
    {
        yield return new WaitForSeconds(heavyspawnInterval);

        if (SpawnAmount > 0)
        {
            if (GameManager.Instance.WaveCount > 5)
            {
                
                SpawnAmount--;
                SpawnZone = Random.Range(SpawnerLeftBorder, SpawnerRightBorder);

                if (GameManager.Instance.DifficultyIncrement >= 2)
                {
                    heavyenemy.GetComponent<EnemyScript>().health += 2;
                    heavyenemy.GetComponent<EnemyScript>().speed += 1;
                    heavyenemy.GetComponent<EnemyScript>().DamageAmount += 1;

                    GameManager.Instance.DifficultyIncrement = 0;
                }

                Vector3 RandomSpawn = new Vector3(SpawnZone, transform.position.y, transform.position.z);
                Instantiate(heavyenemy, RandomSpawn, Quaternion.Euler(0, 180, 0));

                StartCoroutine(HeavySpawn());
            }
        }
    }
}
