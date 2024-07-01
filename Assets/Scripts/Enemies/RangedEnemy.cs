using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    
    [Header ("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;

    [Header ("Ranged Attack")]
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] fireball;

    [Header ("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header ("Player Layer")]
    [SerializeField] private LayerMask playerLayer; 
    private float cooldownTimer = Mathf.Infinity;

    [Header ("Attack Sound")]
    [SerializeField] private AudioClip rangedAttack; 
    
    //References
    private Animator anim;
    private Health playerHealth;

     private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        
        if(PlayerInSight())
        {
            Debug.Log("FOund");
            if(cooldownTimer >= attackCooldown && playerHealth.currentHealth > 0)
            {
                cooldownTimer = 0;
                anim.SetTrigger("attack");
            }
        }
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right *range * transform.localScale.x * colliderDistance,
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y ,boxCollider.bounds.size.z  ), 0, Vector2.left, 0, playerLayer);

        if(hit.collider != null)
            playerHealth = hit.transform.GetComponent<Health>();
            
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right *range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y ,boxCollider.bounds.size.z  ));
    }

    private void RangedAttack()
    {
        SoundManager.instance.PlaySound(rangedAttack);    
        cooldownTimer = 0;

        fireball[FindFireball()].transform.position = firepoint.position;
        fireball[FindFireball()].GetComponent<EnemyProjectile>().ActivateProjectile();
    }

    private int FindFireball(){
        for(int i = 0; i < fireball.Length; i++){
            if(!fireball[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

    private void RemoveCollider(){
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
