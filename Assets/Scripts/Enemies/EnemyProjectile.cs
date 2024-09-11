using UnityEngine;

public class EnemyProjectile : EnemyDamage
{
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    private float lifetime;

    private void Update()
    {
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(-movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
            gameObject.SetActive(false);
    }

    new protected void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player"){
            base.OnTriggerEnter2D(collision); //Execute logic from parent script first
            gameObject.SetActive(false); //When this hits any object deactivate
        }
    }

    public void ActivateProjectile()
    {
        lifetime = 0;
        gameObject.SetActive(true);
    }

    
}
