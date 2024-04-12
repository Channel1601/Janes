using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveOutside : MonoBehaviour
{
    void OnBecameInvisible()
    {
        UnityEngine.Object.Destroy(gameObject);
    }
}
