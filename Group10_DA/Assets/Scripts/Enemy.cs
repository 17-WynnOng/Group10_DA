using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    public float health = 50f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    public void TakeDamage (float amount)
    {
        health -= amount;

        if (health <= 0f)
        {
            Death();
        }
    }

    void Death()
    {
        Destroy(gameObject);
    }
}
