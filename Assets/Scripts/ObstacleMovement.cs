using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(12,(Random.Next(0,2), 0);
        transform.position = transform.position + (Vector3.left * speed * Time.deltaTime);
    }
}
