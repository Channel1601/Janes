using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float MovementSpeed = 0f;
    public float xOff = 0f;
    public float yOff = 0f;
    public float TriggerZoom = -10f;
    public Vector3 newPos;

    // Update is called once per frame
    void Update()
    {
        newPos = new Vector3(target.position.x + xOff, target.position.y + yOff, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, MovementSpeed * Time.deltaTime);
    }



}
