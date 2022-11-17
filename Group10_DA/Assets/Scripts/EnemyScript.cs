using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed;

    public float health;

    public static GameManager gameManager;

    public int DamageInterval;

    public int DamageAmount;

    private bool isAttacking;

    public Animator enemyanim;

    public AudioSource audiosource;
    public AudioClip movement;
    public AudioClip punch;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        audiosource.PlayOneShot(movement);
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

            InvokeRepeating("EnemyDamageInterval", 1, DamageInterval);
        }
    }

    public void EnemyDamageInterval()
    {

        GameManager.Instance.BaseHealth -= DamageAmount;

        enemyanim.SetTrigger("IsAttacking");

        audiosource.PlayOneShot(punch);
    }
}
