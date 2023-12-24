using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Collisions : MonoBehaviour
{
    public float orthographicSize;
    public float Zoom = 10f;
    private float Elapsed = 0f;
    public float ZoomTime = 10f;
    private float percentage;
    [SerializeField] private Camera cam;
    public bool ZoomCollide = false;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            Debug.Log("HIT");
            SceneManager.LoadScene("Level");
        }  
              
            
         

        
     }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ZoomOut"))
        {
            ZoomCollide = true;
            Debug.Log(percentage);
            
        }
    }

    private void Update()
    {
        if (ZoomCollide == true)
        {
            percentage = Elapsed / ZoomTime;
            Elapsed += Time.deltaTime;
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, Zoom, percentage);
            if (percentage == 1)
            {
                ZoomCollide = false;
            }
        }
        
    }



}
