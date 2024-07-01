using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float fallMultiplier = 0f;
    public float jump = 0f;
    public float gSwitchForce = 0f;
    
    [SerializeField] private Rigidbody2D Ninja;
    [SerializeField] private Transform ground;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Cooldown cooldown;

    public float RotationTime;
    private bool gSwitch = false;
    private bool gSwitchDown = false;
    public Animator animator;


    void Update()
    {
        //G Switch
        animator.SetBool("isGrounded", isGrounded());
        if (Input.GetKeyDown(KeyCode.W) && transform.localScale.x > 0 || Input.GetKeyDown(KeyCode.S) && transform.localScale.x < 0)
        {
            animator.SetBool("GravitySwitched", true);
        }
        else 
        {
            animator.SetBool("GravitySwitched", false);
        }

        //jump upright
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded() && transform.localScale.x > 0)
        {
            Ninja.velocity = new Vector2(Ninja.velocity.x, jump);
        }

        //Make fall faster upright
        if (Ninja.velocity.y < 0 && transform.localScale.x > 0)
        {
            Ninja.velocity += Vector2.up * (Physics2D.gravity.y * fallMultiplier * Time.deltaTime);
        }

        //jump upside down
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded() && transform.localScale.x < 0)
        {
            Ninja.velocity = new Vector2(Ninja.velocity.x, -jump);
            Debug.Log("Jump");
        }
 
        if (cooldown.IsCoolingDown) return;
        //Switch to Upside Down
        if (Input.GetKeyDown(KeyCode.W) && Ninja.gravityScale > 0 )
        {

            Ninja.velocity = new Vector2(Ninja.velocity.x,gSwitchForce);
            Ninja.gravityScale *= -1;
            gSwitch = true;
            cooldown.StartCooldown();

        }

        if (gSwitch == true && Ninja.gravityScale < 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y , transform.localScale.z);
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 180);
            gSwitch = false;
        }
        
        //Switch To Upright
        if (cooldown.IsCoolingDown) return;
        if (Input.GetKeyDown(KeyCode.S) && Ninja.gravityScale < 0 )
        {
           
            Ninja.gravityScale *= -1;
            Ninja.velocity = new Vector2(Ninja.velocity.x, -1 * gSwitchForce);
            gSwitchDown = true;
            cooldown.StartCooldown();
  
        }

        if (gSwitchDown == true && Ninja.gravityScale > 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y , transform.localScale.z);
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0);
            gSwitchDown = false;
        }
        
    }
    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(ground.position, 0.5f, groundLayer);
    }    
    
    public bool canAttack()
    {
        return isGrounded();
    }
}
