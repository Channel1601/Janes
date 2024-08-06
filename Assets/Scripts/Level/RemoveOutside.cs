using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveOutside : MonoBehaviour
{
    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
