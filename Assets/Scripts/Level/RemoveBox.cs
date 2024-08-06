using UnityEngine;

public class RemoveBox : MonoBehaviour
{
    void OnBecameVisible(){
         gameObject.SetActive(false);
    }
}
