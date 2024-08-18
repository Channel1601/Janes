using UnityEngine;

public class tornado : MonoBehaviour
{
    public float speed = 0f;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);        
    }
}
