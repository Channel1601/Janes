using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class Collisions : MonoBehaviour
{
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            Debug.Log("HIT");
            SceneManager.LoadScene("Level");
        }          
     }





}
