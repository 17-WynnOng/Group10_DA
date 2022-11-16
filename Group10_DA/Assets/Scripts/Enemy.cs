﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    public float health = 50f;

    public static GameManager gameManager;

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

    public void OnCollisionStay(Collision other)
    {
        if(other.gameObject.tag == "Wall")
        {
            speed = 0;
        }
    }

    public IEnumerator EnemyDamageInterval()
    {
        yield return new WaitForSeconds(2);

        GameManager.Instance.BaseHealth -= 5;
    }
}
