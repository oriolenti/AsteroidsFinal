using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public float limitX;
    public float limitY;

    void Update()
    {
        if (transform.position.y > limitY)
        {
            transform.position = new Vector3 (transform.position.x, -limitY, transform.position.z);
        }

        if (transform.position.y < -limitY)
        {
            transform.position = new Vector3(transform.position.x, limitY, transform.position.z);
        }

        if (transform.position.x > limitX)
        {
            transform.position = new Vector3(-limitX, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -limitX)
        {
            transform.position = new Vector3(limitX, transform.position.y, transform.position.z);
        }
    }
}
