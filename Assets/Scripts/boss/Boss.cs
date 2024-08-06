using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Animator anim;
    public GameObject bossBar;
    public Health health;

    void Awake()
    {
        gameObject.SetActive(false);
        bossBar.SetActive(false);
    }

    void Update()
    {
        if(health.currentHealth == 10)
            anim.SetTrigger("stageTwo");
    }

    public void SpawnBoss()
    {
        gameObject.SetActive(true);
        anim.SetTrigger("Spawn");
        bossBar.SetActive(true);
        StartCoroutine(Attacks());
    }

    private IEnumerator Attacks()
    {
        yield return new WaitForSeconds(5f);
    }
}
