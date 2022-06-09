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
    private short lifeCount = 3;
    private GameObject[] lifes;

    private float defaultScale;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        defaultScale = transform.localScale.x;

        //Lebensanzeige generieren
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
            transform.localScale = new Vector3(defaultScale, transform.localScale.y, transform.localScale.z);
        else if (Input.GetAxis("Horizontal") < 0)
            transform.localScale = new Vector3(-defaultScale, transform.localScale.y, transform.localScale.z);
    }

    private void OnTriggerEnter2D(Collider2D collision) //Kollisionserkennung
    {
        setLife((short)(getLife() - 1));
    }

    public short getLife()
    {
        return lifeCount;
    }

    public void setLife(short value)
    {
        if (value > defaultLife)
            lifeCount = defaultLife;
        else if (value < 0)
            lifeCount = 0;
        else
            lifeCount = value;

        for (int i = 0; i < defaultLife; i++)
        {
            if (lifeCount < i+1)
                lifes[i].SetActive(false);
            else
                lifes[i].SetActive(true);
        }
    }
}
