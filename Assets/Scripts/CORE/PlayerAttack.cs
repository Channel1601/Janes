using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] shurikens;

    private Animator animator;
    private movement movement;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        movement = GetComponent<movement>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(1) && cooldownTimer > attackCooldown && movement.canAttack())
        {
            StartCoroutine(Attack());
        }
        cooldownTimer += Time.deltaTime;

        
    }

    private IEnumerator Attack()
    {
        animator.SetTrigger("attack");
        cooldownTimer = 0;

        yield return new WaitForSeconds(0.15f);
        //poll attack
        shurikens[FindFireball()].transform.position = firePoint.position;
        shurikens[FindFireball()].GetComponent<Attack>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindFireball()
    {
        for (int i = 0; i < shurikens.Length; i++)
        {
            if (!shurikens[i].activeInHierarchy)
            {
                return i;
            }
        }
        
        return 0;
    }

    public void Shuriken()
    {
        if (cooldownTimer > attackCooldown && movement.canAttack())
        {
            StartCoroutine(Attack());
        }
        cooldownTimer += Time.deltaTime;
    }
}
