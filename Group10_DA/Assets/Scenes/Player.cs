using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        
        if(Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if(transform.position.x < -7.55f)
        {
            this.transform.position = new Vector3(-7.55f, transform.position.y, transform.position.z);
        }

        if(transform.position.x > 20.322f)
        {
            this.transform.position = new Vector3(20.322f, transform.position.y, transform.position.z);
        }
    }
}
