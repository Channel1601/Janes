using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Death : MonoBehaviour
{
    public Rigidbody2D Ninja; 

    // Start is called before the first frame update
 
    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.tag == "Death")
        {
            Debug.Log("HIT");
            SceneManager.LoadScene("Level");
        }

        
    }

 


}
