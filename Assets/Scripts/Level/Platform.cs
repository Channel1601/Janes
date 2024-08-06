using System.Collections;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Animator anim;
    public float destroyTime;

    void OnTriggerEnter2D(Collider2D collide)
    {
        if(collide.CompareTag("Player"))
        {            
            StartCoroutine(breakPlatform());
        }
    }

    private IEnumerator breakPlatform()
    {
        yield return new WaitForSeconds(destroyTime);
        anim.SetTrigger("break");
    }

    private void RemoveCollider(){
        GetComponent<BoxCollider2D>().enabled = false;
    }

    private void breakPlat()
    {
        gameObject.SetActive(false);
    }
}
