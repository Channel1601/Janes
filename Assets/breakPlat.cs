using UnityEngine;

public class breakPlat : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collide)
    {
        if(collide.CompareTag("Player") && collide.GetComponent<Health>() != null)
        {            
            Animator anim = gameObject.transform.parent.GetComponent<Animator>();
            anim.SetTrigger("break");
        }
    }
}
