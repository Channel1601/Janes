using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public float jump = 5f;
    public float gSwitchForce = 5f;
    
    [SerializeField] private Rigidbody2D Ninja;
    [SerializeField] private Transform ground;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private bool ZoomCollide;
    [SerializeField] private Cooldown cooldown;
    public float RotationTime;
    private float percentage;
    private bool gSwitch = false;
    private bool gSwitchDown = false;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isGrounded", isGrounded());
        if (Input.GetKeyDown(KeyCode.W) && transform.localScale.x > 0 || Input.GetKeyDown(KeyCode.S) && transform.localScale.x < 0)
        {
            animator.SetBool("GravitySwitched", true);
        }
        else 
        {
            animator.SetBool("GravitySwitched", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded() && transform.localScale.x > 0)
        {
            Ninja.velocity = new Vector2(Ninja.velocity.x, jump);
  
        }
        if (Input.GetButtonUp("Jump") && isGrounded() && Ninja.velocity.y > 0f)
        {
            Ninja.velocity = new Vector2(Ninja.velocity.x, Ninja.velocity.y * 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded() && transform.localScale.x < 0)
        {
            Ninja.velocity = new Vector2(Ninja.velocity.x, -jump);

        }
        if (Input.GetButtonUp("Jump") && isGrounded() && Ninja.velocity.y > 0f)
        {
            Ninja.velocity = new Vector2(Ninja.velocity.x, Ninja.velocity.y * 0.5f);
        }


        if (cooldown.IsCoolingDown) return;
        if (Input.GetKeyDown(KeyCode.W) && Ninja.gravityScale > 0 )
        {
            Ninja.velocity = new Vector2(Ninja.velocity.x,gSwitchForce);
            Ninja.gravityScale *= -1;
            gSwitch = true;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            cooldown.StartCooldown();
        }

        if (gSwitch == true && Ninja.gravityScale < 0)
        {
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 180);
            gSwitch = false;
        }
        

        if (cooldown.IsCoolingDown) return;
        if (Input.GetKeyDown(KeyCode.S) && Ninja.gravityScale < 0 )
        {
            Ninja.gravityScale *= -1;
            Ninja.velocity = new Vector2(Ninja.velocity.x, -1 * gSwitchForce);
            gSwitchDown = true;
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, Mathf.Lerp(transform.eulerAngles.z, 180, percentage));
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            cooldown.StartCooldown();
        }

        if (gSwitchDown == true && Ninja.gravityScale > 0)
        {
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y,0);
            gSwitchDown = false;
        }
        
    }
    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(ground.position, 0.5f, groundLayer);
    }    
    

}
