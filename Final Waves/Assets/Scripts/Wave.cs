using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public float hSpeed = 0f;
    public float vSpeed = 5f;
    private Level level;

    private void Start()
    {
        level = GetComponentInParent<Level>();

        //Drehung
        if (hSpeed < 0)
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y,transform.localScale.z);
    }

    void FixedUpdate()
    {
        if (transform.position.y < level.activationY) {
             //Steuerung
             transform.position = new Vector3(transform.position.x + hSpeed * Time.deltaTime, transform.position.y + vSpeed * Time.deltaTime, 0f);

            if (transform.position.y < level.deathY)
                Destroy(this.gameObject);
        }
    }
}
