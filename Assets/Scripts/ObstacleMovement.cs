using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 5;

    void Update()
    {
       transform.position = transform.position + (Vector3.left * speed * Time.deltaTime);

    }
}

