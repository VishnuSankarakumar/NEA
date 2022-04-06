using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Player
{

    public Vector2 mousePos1;
    void Update()
    {
        mousePos1 = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    new void FixedUpdate()
    {        
        Vector2 lookDir = mousePos1 - rb.position;
        float angle =  Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        if (mousePos1.x < rb.position.x)
        {
            angle = (Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg) + 180f;
            Debug.Log("left");
        }
        else
        {
            angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
            Debug.Log("right");
        }
        
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
