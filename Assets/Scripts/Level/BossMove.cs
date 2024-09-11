using UnityEngine;

public class BossMove : MonoBehaviour
{
    public float speed = 10;

    void FixedUpdate()
    {
        transform.position += Vector3.left * speed * Time.fixedDeltaTime;
    }
}
