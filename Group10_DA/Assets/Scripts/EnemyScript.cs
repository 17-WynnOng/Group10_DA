using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed;

    public float health;

    public static GameManager gameManager;

    public float DamageInterval;

    public int DamageAmount;

    public Animator enemyanim;

    public AudioSource audiosource;
    public AudioClip normalpunch;
    public AudioClip[] normalfootsteps;
    public AudioClip heavyfootsteps;
    public AudioClip heavypunch;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    public void TakeDamage (float amount)
    {
        health -= amount;

        Debug.Log("Hit");

        if (health <= 0f)
        {
            Death();
        }
    }

    void Death()
    {
        Destroy(gameObject);

        GameManager.Instance.EnemyCountUpdate();
    }

    public void OnCollisionEnter(Collision other)
    {

        if(other.gameObject.tag == "Wall")
        {
            speed = 0;

            InvokeRepeating("EnemyDamageInterval", 0, DamageInterval);
        }
    }

    public void EnemyDamageInterval()
    {

        GameManager.Instance.BaseHealth -= DamageAmount;

        enemyanim.SetTrigger("IsAttacking");
    }

    public void NormalEnemyPunchSound()
    {
       audiosource.PlayOneShot(normalpunch, 0.7f);
    }

    public void NormalEnemyFootstepSound()
    {
        audiosource.PlayOneShot(normalfootsteps[Random.Range(0, 4)], 1.7f);
    }

    public void HeavyEnemyFootstepSound()
    {
        audiosource.PlayOneShot(heavyfootsteps, 0.8f);
    }

    public void HeavyEnemyPunchSound()
    {
        audiosource.PlayOneShot(heavypunch, 0.8f);
    }
}
