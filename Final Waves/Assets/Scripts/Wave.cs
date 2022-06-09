using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public float hSpeed = 0f;
    public float vSpeed = 5f;

    void FixedUpdate()
    {
        //Steuerung
        transform.position = new Vector3(transform.position.x + hSpeed * Time.deltaTime, transform.position.y + vSpeed * Time.deltaTime,0f);
    }
}
