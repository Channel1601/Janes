using UnityEngine;

public class DestroyOutside : MonoBehaviour
{
    void OnBecameInvisible()
    {
        Destroy(transform.parent.gameObject);
    }
}
