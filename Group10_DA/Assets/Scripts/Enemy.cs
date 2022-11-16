using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    public float health = 50f;

    public static GameManager gameManager;

    public int DamageInterval;

    public int DamageAmount;

    private bool isAttacking;

    public Animator enemyanim;

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

            InvokeRepeating("EnemyDamageInterval", 1, DamageInterval);
        }
    }

    public void EnemyDamageInterval()
    {

        GameManager.Instance.BaseHealth -= DamageAmount;

        enemyanim.SetTrigger("IsAttacking");
    }
}
