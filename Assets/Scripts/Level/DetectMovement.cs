using UnityEngine;

public class DetectMovement : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 newPosition = rb.position + Vector2.left * speed * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);
    }
}
