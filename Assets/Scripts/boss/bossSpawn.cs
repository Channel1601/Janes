using UnityEngine;

public class bossSpawn : MonoBehaviour
{
    public GameObject boss;

    private ObstacleMovement obstacleMovement;
    
    void Awake()
    {
        obstacleMovement = GetComponentInParent<ObstacleMovement>();
    }

    void OnTriggerEnter2D(Collider2D collide)
    {
        if(collide.CompareTag("Player"))
        {            
            boss.GetComponent<Boss>().SpawnBoss();
            obstacleMovement.enabled = false;
            gameObject.SetActive(false);
        }
    }

    
}
