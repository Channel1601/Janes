using System.Collections;
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

    #region Tornado
    private void OnCollisionEnter2D (Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player")) 
            StartCoroutine(Nado(false));
    }

    private void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player")) 
            StartCoroutine(Nado(true));
    }

    private IEnumerator Nado(bool state)
    {
        yield return new WaitForSeconds(0.5f);
        ObstacleMovement[] scripts = FindObjectsOfType<ObstacleMovement>();
        foreach (ObstacleMovement script in scripts)
        {
            script.enabled = state;
        }
        
        DetectMovement[] scrips = FindObjectsOfType<DetectMovement>();
        foreach (DetectMovement script in scrips)
        {
            script.enabled = state;
        }
    }
    #endregion
}
