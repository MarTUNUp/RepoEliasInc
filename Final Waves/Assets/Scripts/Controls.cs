using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    public float speed = 5f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //Steuerung
        rigidbody.MovePosition(new Vector2 (transform.position.x + speed * Input.GetAxis("Horizontal") * Time.deltaTime, transform.position.y + speed * Input.GetAxis("Vertical") * Time.deltaTime));

        if (Input.GetAxis("Horizontal") > 0)
            transform.localScale = new Vector3(0.25f, 0.25f, 1);
        else if (Input.GetAxis("Horizontal") < 0)
            transform.localScale = new Vector3(-0.25f, 0.25f, 1);
    }
}
