using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunOrientation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateTowardsTarget();
    }

    private void RotateTowardsTarget()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            RotateTowardsMouse(hit.point);
        }

    }

    private void RotateTowardsMouse(Vector3 TargetPosition)
    {
        Vector3 DirectionVector = TargetPosition - this.transform.position;

        this.transform.forward = DirectionVector;
    }


}
