using UnityEngine;

public class bossSpawn : MonoBehaviour
{
    public GameObject boss;

    private BossMove bossMove;
    
    void Awake()
    {
        bossMove = GetComponentInParent<BossMove>();
    }

    void OnTriggerEnter2D(Collider2D collide)
    {
        if(collide.CompareTag("Player"))
        {            
            boss.GetComponent<Boss>().SpawnBoss();
            bossMove.enabled = false;
            gameObject.SetActive(false);
        }
    }

    
}
