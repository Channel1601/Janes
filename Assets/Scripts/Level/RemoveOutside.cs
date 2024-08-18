using UnityEngine;

public class RemoveOutside : MonoBehaviour
{
    void OnBecameInvisible()
    {
        if (this != null && gameObject != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject, 0.1f);
        }
    }
}
