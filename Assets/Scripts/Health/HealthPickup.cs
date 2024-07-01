using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] private float healthValue;
    [SerializeField] private AudioClip pickup;

    private void OnTriggerEnter2D(Collider2D collision){

        if (collision.tag == "Player")
        {
            SoundManager.instance.PlaySound(pickup);
            collision.GetComponent<Health>().AddHealth(healthValue);
            gameObject.SetActive(false);
        }
    }
}
