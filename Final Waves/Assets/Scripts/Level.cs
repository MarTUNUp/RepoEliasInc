using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public float activationY;
    public float deathY;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, transform.position.y - 5 * Time.deltaTime, 0f);
    }
}
