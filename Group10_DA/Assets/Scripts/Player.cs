using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    public float damage;
    public float boundaryleft;
    public float boundaryright;
    public Texture2D crosshair;
    public GameObject hiteffect;
    public Text AmmoTxt;
    public int MaxAmmo;
    private int AmmoCount;
    public float ReloadTime;
    public bool isReloading;
    
    // Start is called before the first frame update
    void Start()
    {
        Vector2 hotSpot = new Vector2(crosshair.width / 2f, crosshair.height / 2f);
        Cursor.SetCursor(crosshair, hotSpot, CursorMode.ForceSoftware);

        AmmoCount = MaxAmmo;

        AmmoTxt.text = "" + AmmoCount;
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

        if(transform.position.x < boundaryleft)
        {
            this.transform.position = new Vector3(boundaryleft, transform.position.y, transform.position.z);
        }

        if(transform.position.x > boundaryright)
        {
            this.transform.position = new Vector3(boundaryright, transform.position.y, transform.position.z);
        }

        

        if (Input.GetKeyDown(KeyCode.Mouse0) && isReloading == false)
        {
            if (AmmoCount > 0)
            {
                Shoot();
                AmmoTxt.text = "" + AmmoCount;
            }
            else
            {
                AmmoTxt.text = "reload";
                AmmoCount = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.R) && isReloading == false)
        {
            isReloading = true;
            StartCoroutine(Reload(ReloadTime));
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        AmmoCount--;
        if (Physics.Raycast(ray, out hit, 100))    
        {
            EnemyScript enemy = hit.transform.GetComponent<EnemyScript>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                
            }
            
            GameObject gameObject = Instantiate(hiteffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(gameObject, 2f);
        }
    }

    IEnumerator Reload(float time)
    {

        AmmoTxt.text = "reloading";

        yield return new WaitForSeconds(time);

        AmmoCount = MaxAmmo;
        AmmoTxt.text = "" + AmmoCount;
        isReloading = false;
    }
}
