using UnityEngine;

public class BossProjectile : EnemyDamage
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

    public void ActivateProjectile()
    {
        lifetime = 0;
        gameObject.SetActive(true);
    }
}
