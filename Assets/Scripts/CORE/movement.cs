using UnityEngine;
using UnityEngine.UI;

public class movement : MonoBehaviour
{
    public float fallMultiplier = 0f;
    public float jump = 0f;
    public float gSwitchForce = 0f;
    
    [SerializeField] private Rigidbody2D Ninja;
    [SerializeField] private Transform ground;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Cooldown cooldown;

    [Header("Switch Buttons")]
    [SerializeField] private GameObject switchUp;
    [SerializeField] private GameObject switchDown;
    
    public float RotationTime;
    private bool gSwitch = false;
    private bool gSwitchDown = false;
    public Animator animator;


    void Update()
    {
        animator.SetBool("isGrounded", isGrounded());
        
        jumpsKBM();

        gravSwitchKBM();     
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(ground.position, 0.5f, groundLayer);
    }    
    
    public bool canAttack()
    {
        return isGrounded();
    }

    private void jumpsKBM()
    {
        //jump upright
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded() && transform.localScale.x > 0)
        {
            animator.SetTrigger("jump");
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
            animator.SetTrigger("jump");
            Ninja.velocity = new Vector2(Ninja.velocity.x, -jump);
            Debug.Log("Jump");
        }
    }

    private void gravSwitchKBM()
    {
        if (cooldown.IsCoolingDown) return;
        if (Input.GetKeyDown(KeyCode.W) && Ninja.gravityScale > 0 )
        {
            animator.SetTrigger("GravitySwitch");
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
            animator.SetTrigger("GravitySwitch");
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

    public void jumpsButton()
    {
        //jump upright
        if (isGrounded() && transform.localScale.x > 0)
        {
            animator.SetTrigger("jump");
            Ninja.velocity = new Vector2(Ninja.velocity.x, jump);
        }

        //Make fall faster upright
        if (Ninja.velocity.y < 0 && transform.localScale.x > 0)
        {
            Ninja.velocity += Vector2.up * (Physics2D.gravity.y * fallMultiplier * Time.deltaTime);
        }

        //jump upside down
        if (isGrounded() && transform.localScale.x < 0)
        {
            animator.SetTrigger("jump");
            Ninja.velocity = new Vector2(Ninja.velocity.x, -jump);
            Debug.Log("Jump");
        }
    }

    public void gravSwitchButton()
    {
        if (cooldown.IsCoolingDown) return;
        if (Ninja.gravityScale > 0 )
        {
            animator.SetTrigger("GravitySwitch");
            Ninja.velocity = new Vector2(Ninja.velocity.x,gSwitchForce);
            Ninja.gravityScale *= -1;
            gSwitch = true;
            cooldown.StartCooldown();
            switchUp.SetActive(false);
            switchDown.SetActive(true);
        }

        if (gSwitch == true && Ninja.gravityScale < 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y , transform.localScale.z);
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 180);
            gSwitch = false;
            
        }
        
        //Switch To Upright
        
        if (cooldown.IsCoolingDown) return;
        if (Ninja.gravityScale < 0 )
        {
            animator.SetTrigger("GravitySwitch");
            Ninja.gravityScale *= -1;
            Ninja.velocity = new Vector2(Ninja.velocity.x, -1 * gSwitchForce);
            gSwitchDown = true;
            cooldown.StartCooldown();
            switchUp.SetActive(true);
            switchDown.SetActive(false);
        }

        if (gSwitchDown == true && Ninja.gravityScale > 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y , transform.localScale.z);
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0);
            gSwitchDown = false;
            
        }
    }


}
