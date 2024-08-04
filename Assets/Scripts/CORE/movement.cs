using UnityEngine;
using UnityEngine.UI;

public class movement : MonoBehaviour
{
    public float fallMultiplier = 0f;
    public float jump = 0f;
    public float gSwitchForce = 0f;
    private bool gSwitch = true;

    [SerializeField] private Rigidbody2D Ninja;
    [SerializeField] private Transform ground;
    [SerializeField] private LayerMask groundLayer;

    [Header("Switch Buttons")]
    [SerializeField] private Button switchUp;
    [SerializeField] private Button switchDown;

    public float RotationTime;
    public Animator animator;
    
    private float coyoteTime = 0.15f;
    private float coyoteTimeCounter;
    
    void Update()
    {
        animator.SetBool("isGrounded", isGrounded()); 
          
        if(isGrounded())
        {
            coyoteTimeCounter = coyoteTime;
            gSwitch = true;
        }else{
            coyoteTimeCounter -= Time.deltaTime;
        }

         //Make fall faster upright
        if (Ninja.velocity.y < 0 && transform.localScale.x > 0)
        {
            Ninja.velocity += Vector2.up * (Physics2D.gravity.y * fallMultiplier * Time.deltaTime);
        }

        if(!gSwitch)
        {
            switchUp.interactable = false;
            switchDown.interactable = false;
        }else{
            switchUp.interactable = true;
            switchDown.interactable = true;
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

    public void jumpsButton()
    {
        //jump upright
        if (coyoteTimeCounter > 0f && transform.localScale.x > 0)
        {
            animator.SetTrigger("jump");
            Ninja.velocity = new Vector2(Ninja.velocity.x, jump);
            coyoteTimeCounter = 0;
        }

        //jump upside down
        if (coyoteTimeCounter > 0f && transform.localScale.x < 0 )
        {
            animator.SetTrigger("jump");
            Ninja.velocity = new Vector2(Ninja.velocity.x, -jump);
            coyoteTimeCounter = 0;
        }
    }

    private void gSwitchCon(Button bEnable, Button bDisable, int rotate, int gForce)
    {
        animator.SetTrigger("GravitySwitch");
        Ninja.gravityScale *= -1;
        Ninja.velocity = new Vector2(Ninja.velocity.x, gForce * gSwitchForce);
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y , transform.localScale.z);
        bEnable.gameObject.SetActive(true);
        bDisable.gameObject.SetActive(false);
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, rotate);
    }

    public void gravSwitchButtonUP()
    {
        if(gSwitch){
            gSwitchCon(switchDown, switchUp, 180, 1);
            gSwitch = false;
        }            
    }

    public void gravSwitchButtonDOWN()
    {
        if(gSwitch){
            gSwitchCon(switchUp, switchDown, 0, -1);
            gSwitch = false;
        }    
    }
}
