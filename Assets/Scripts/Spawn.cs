using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    private float timer = 0;
    public float spawnRate = 1;
    public GameObject obst;
    // Start is called before the first frame update
    void Start()
    {
        obstSpawner();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
            //Debug.Log(Random.Next(0, 2));
        }
        else 
        {
            obstSpawner();
        }
    }
    void obstSpawner()
    {
        Instantiate(obst, transform.position, transform.rotation);
        timer = 0;
    }
}
