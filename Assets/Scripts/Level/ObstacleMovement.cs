using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 10;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}

