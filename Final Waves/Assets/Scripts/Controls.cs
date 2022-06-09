using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controls : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    public GameObject panel;
    public GameObject life;
    public float hMargin = 30f;
    public float vMargin = 0f;
    public float speed = 5f;
    public short defaultLife = 3;
    public short lifeCount = 3;
    private GameObject[] lifes;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        lifes = new GameObject[defaultLife];
        for(int i = 0; i < defaultLife; i++)
        {
            lifes[i] = Instantiate(life);
            lifes[i].transform.SetParent(panel.transform);
            lifes[i].GetComponent<RectTransform>().localPosition =new Vector3(hMargin*i,vMargin*i, 0);
        }
    }

    void FixedUpdate()
    {
        //Steuerung
        rigidbody.MovePosition(new Vector2 (transform.position.x + speed * Input.GetAxis("Horizontal") * Time.deltaTime, transform.position.y + speed * Input.GetAxis("Vertical") * Time.deltaTime));


        //Drehung
        if (Input.GetAxis("Horizontal") > 0)
            transform.localScale = new Vector3(0.25f, 0.25f, 1);
        else if (Input.GetAxis("Horizontal") < 0)
            transform.localScale = new Vector3(-0.25f, 0.25f, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }
}
