using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public float jump = 5f;

    [SerializeField] private Rigidbody2D Ninja;
    [SerializeField] private Transform ground;
    [SerializeField] private LayerMask groundLayer; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            Ninja.velocity = new Vector2(Ninja.velocity.x, jump);
            Debug.Log("Jump!");
        }
        if (Input.GetButtonUp("Jump") && Ninja.velocity.y > 0f)
        {
            Ninja.velocity = new Vector2(Ninja.velocity.x, Ninja.velocity.y * 0.5f);
        }

    }
    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(ground.position, 0.5f, groundLayer);
    }    
    

}
