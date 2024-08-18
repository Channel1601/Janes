using UnityEngine;

public class RemoveBox : MonoBehaviour
{
    void OnBecameVisible(){
        Destroy(gameObject);
    }
}
